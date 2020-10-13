using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Activation;
using System.IO;

[ServiceBehavior]
[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
public class TransferService : ITransferService
{
    public RemoteFileInfo DownloadFile(DownloadRequest request)
    {
        RemoteFileInfo result = new RemoteFileInfo();

        try
        {
            // get some info about the input file
            request.FileName = "kate-upton.jpg";
            string filePath = Path.Combine(AppDomain.CurrentDomain.GetData("DataDirectory").ToString(), request.FileName);
            FileInfo fileInfo = new FileInfo(filePath); 

            // check if exists
            if (!fileInfo.Exists) throw new FileNotFoundException("File not found", request.FileName);

            // open stream
            FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

            // return result

            result.FileName = request.FileName;
            result.Length = fileInfo.Length;
            result.FileByteStream = stream;
        }
        catch (Exception ex)
        {

        }

        return result;

     }



    public void UploadFile(RemoteFileInfo request)
    {
        FileStream targetStream = null;
        Stream sourceStream =  request.FileByteStream;

        string uploadFolder = @"C:\upload\";
         string filePath = Path.Combine(uploadFolder, request.FileName); 

        using (targetStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
        {
            //read from the input stream in 6K chunks
            //and save to output stream
            const int bufferLen = 65000; 
            byte[] buffer = new byte[bufferLen];
            int count = 0;
            while ((count = sourceStream.Read(buffer, 0, bufferLen)) > 0)
            {
                targetStream.Write(buffer, 0, count);
            }
            targetStream.Close();
            sourceStream.Close();
        }

    }

}
