using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;
using Microsoft.Azure.CognitiveServices.Vision.Face;

namespace FaceRecognition
{
    public class FaceRecognition
    {
        VideoCapture photo = new VideoCapture(0);
        Mat frame = new Mat();
        Mat grayImage = new Mat();
        public async Task<string> Recognition()
        {

            string apiKey = "11d9174165dc4e2eb2a55f15c0302487"; // Azure Face API 키
            string endpoint = "https://facelocate.cognitiveservices.azure.com/"; // Azure Face API 엔드포인트

            IFaceClient faceClient = new FaceClient(new ApiKeyServiceClientCredentials(apiKey))
            {
                Endpoint = endpoint
            };
            photo.Read(frame);
            var frameStream = frame.ToMemoryStream();
            var detectedFaces = await faceClient.Face.DetectWithStreamAsync(frameStream);
            int[] faceSize = new int[detectedFaces.Count];
            int faceCount = 0;
            int MostBigFace = 0;
            foreach (var face in detectedFaces)
            {
                Console.WriteLine($"얼굴 ID: {face.FaceId}");
                Console.WriteLine($"얼굴 위치: X={face.FaceRectangle.Left}, Y={face.FaceRectangle.Top}, 너비={face.FaceRectangle.Width}, 높이={face.FaceRectangle.Height}");
                Cv2.Rectangle
                    (
                    frame,
                    new OpenCvSharp.Point(face.FaceRectangle.Left, face.FaceRectangle.Top),
                    new OpenCvSharp.Point(face.FaceRectangle.Left + face.FaceRectangle.Width, face.FaceRectangle.Top + face.FaceRectangle.Height),
                    new Scalar(255, 0, 0), 2
                    );
                faceSize[faceCount] = face.FaceRectangle.Width * face.FaceRectangle.Height;

                if (faceCount != 0)
                {
                    if (faceSize[faceCount] > faceSize[MostBigFace])
                        MostBigFace = faceCount;
                }
            }
            Console.Write(detectedFaces[MostBigFace].FaceRectangle.Top);

            return detectedFaces[MostBigFace].FaceRectangle.Top.ToString();
        }
    }
}
