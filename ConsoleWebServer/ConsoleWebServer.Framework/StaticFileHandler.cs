using System;
using System.IO;
using System.Linq;
using System.Net;
using str = System.String;

public class StaticFileHandler
{
    public bool CanHandle(HttpRq request)
    {
        return request.Uri.LastIndexOf(".", StringComparison.Ordinal) >
               request.Uri.LastIndexOf("/", StringComparison.Ordinal);
    }

    public HttpResponse Handle(HttpRq request)
    {
        str filePath = string.Format("{0}/{1}", Environment.CurrentDirectory, request.Uri);
        if (!this.FileExists("C:\\", filePath, 3))
        {
            return new HttpResponse(request.ProtocolVersion, HttpStatusCode.NotFound, "File not found");
        }
        str fileContents = File.ReadAllText(filePath);
        var response = new HttpResponse(request.ProtocolVersion, HttpStatusCode.OK, fileContents);
        return response;
    }

    private bool FileExists(str path, str filePath, int depth)
    {
        if (depth <= 0)
        {
            return File.Exists(filePath);
        }
        try
        {
            string[] f = Directory.GetFiles(path);
            if (f.Contains(filePath))
            {
                return true;
            }
            string[] d = Directory.GetDirectories(path);
            foreach (str dd in d)
            {
                if (this.FileExists(dd, filePath, depth - 1))
                {
                    return true;
                }
            }
            return false;
        }
        catch (Exception)
        {
            return false;
        }
    }
}