using System;
using System.IO;

public static class FormatFileSize
{
    static readonly string[] Sizes = { "B", "KB", "MB", "GB", "TB" };

    public static string GetFileSize(long bytes)
    {
        //file size in bytes to be converted
        double size = bytes;
        int order = 0;

        while (size >= 1024 && order < Sizes.Length - 1)
        {
            order++;
            size /= 1024;
        }
        
        return $"{size:0.##} {Sizes[order]}";
    }
}