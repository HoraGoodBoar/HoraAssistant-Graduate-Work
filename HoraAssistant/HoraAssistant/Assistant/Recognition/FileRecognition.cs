using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace HoraAssistant { 
    public static class FileRecognition{
        public static void LoadFileToRequest(string NameFile, ref WebRequest Request) {
            byte[] byteArray = File.ReadAllBytes(NameFile);
            if (byteArray.Length / 1024 <= DataRecognition.MinByteFromTranslate){
                Request = null;
                return;
            }
            Request.ContentType = "audio/l16; rate=16000";
            Request.ContentLength = byteArray.Length;
            Request.GetRequestStream().Write(byteArray, 0, byteArray.Length);
        }
    }
}
