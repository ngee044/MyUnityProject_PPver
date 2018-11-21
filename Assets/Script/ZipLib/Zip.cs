
using UnityEngine;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

public class Zip
{
    public delegate void DeCompressing(long DeCompsize);
    static DeCompressing m_CB_DeCompress = null;

    static public void SetCB_DeCompress( DeCompressing cb )
    {
        m_CB_DeCompress = cb;
    }


    static public void Compression( string ZipPath, string Root, List< string > zipSrcList )
    {
        try
        {
            string zipPath = ZipPath + ".zip";
            
            System.IO.FileStream writer = new System.IO.FileStream(zipPath,
                                            System.IO.FileMode.Create,
                                             System.IO.FileAccess.Write, System.IO.FileShare.Write);

            ICSharpCode.SharpZipLib.Zip.ZipOutputStream zos =
                                new ICSharpCode.SharpZipLib.Zip.ZipOutputStream(writer);

            string file = "";
            int cnt = zipSrcList.Count;
            for (int i = 0; i < cnt; ++i )
            {
                if (Root != null)
                    file = string.Format("{0}/{1}", Root, zipSrcList[i]);
                else
                    file = zipSrcList[i];

                ICSharpCode.SharpZipLib.Zip.ZipEntry ze =
                                         new ICSharpCode.SharpZipLib.Zip.ZipEntry(zipSrcList[i]);

                System.IO.FileStream fs = new System.IO.FileStream(file,
                                 System.IO.FileMode.Open, System.IO.FileAccess.Read,
                                      System.IO.FileShare.Read);

                byte[] buffer = new byte[fs.Length];
                fs.Read(buffer, 0, buffer.Length);
                fs.Close();

                ze.Size = buffer.Length;

                ze.DateTime = DateTime.Now;

                // 새로운 엔트리(파일)을 넣는다.
                zos.PutNextEntry(ze);

                // 쓰기
                zos.Write(buffer, 0, buffer.Length);
            }
            zos.Close();
            writer.Close();
        }
        catch (Exception ex)
        {
            Debug.LogError( "Zip Error : " + ex.ToString());
        }
    }

    static public long GetDeCompressFileSize(string zipPath)
    {
        long res = 0;

        System.IO.FileStream fs = new System.IO.FileStream(zipPath,
                                             System.IO.FileMode.Open,
                                     System.IO.FileAccess.Read, System.IO.FileShare.Read);

        ICSharpCode.SharpZipLib.Zip.ZipInputStream zis =
                                new ICSharpCode.SharpZipLib.Zip.ZipInputStream(fs);

        try
        {
            ICSharpCode.SharpZipLib.Zip.ZipEntry ze;
            while ((ze = zis.GetNextEntry()) != null)
            {
                if (!ze.IsDirectory)
                {
                    res += ze.Size;
                }
            }
        }
        catch (Exception e)
        {
            Debug.Log(e);
            res = 0;
        }

        zis.Close();
        fs.Close();

        return res;
    }


    // 해제
    static public bool DeCompression(string zipPath, string dest, ref string Exception )
    {
        string extractDir = dest;

        System.IO.FileStream fs = new System.IO.FileStream(zipPath,
                                             System.IO.FileMode.Open,
                                     System.IO.FileAccess.Read, System.IO.FileShare.Read);

        ICSharpCode.SharpZipLib.Zip.ZipInputStream zis =
                                new ICSharpCode.SharpZipLib.Zip.ZipInputStream(fs);

        bool bRes = true;
        
        try
        {
            long t_size = 0;

            ICSharpCode.SharpZipLib.Zip.ZipEntry ze;            

            while ((ze = zis.GetNextEntry()) != null)
            {
                if (!ze.IsDirectory)
                {
                    string fileName = System.IO.Path.GetFileName(ze.Name);
                    string destDir = System.IO.Path.Combine(extractDir,
                                     System.IO.Path.GetDirectoryName(ze.Name));

                    if (false == Directory.Exists(destDir))
                    {
                        System.IO.Directory.CreateDirectory(destDir);
                    }

                    string destPath = System.IO.Path.Combine(destDir, fileName);

                    System.IO.FileStream writer = new System.IO.FileStream(
                                    destPath, System.IO.FileMode.Create,
                                            System.IO.FileAccess.Write,
                                                System.IO.FileShare.Write);

                    byte[] buffer = new byte[2048];
                    int len;
                    while ((len = zis.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        writer.Write(buffer, 0, len);
                    }

                    writer.Close();

                    if( m_CB_DeCompress != null )
                    {
                        t_size += ze.Size;
                        m_CB_DeCompress(t_size);
                    }                    
                }
            }
        }
        catch( Exception e)
        {
            bRes = false;
            Exception = e.Message;
        }        

        zis.Close();
        fs.Close();

        return bRes;
    }

}
