using Microsoft.Azure.CognitiveServices.Vision.Face;
using OpenCvSharp;
using System;
using System.Threading.Tasks;

namespace FaceRecognition
{
    public class FaceRecognition
    {

        public async Task<string> Recognition()
        {
            VideoCapture photo = new VideoCapture(0);
            Mat frame = new Mat();

            Console.WriteLine("얼굴인식시작");
            string apiKey = "11d9174165dc4e2eb2a55f15c0302487"; // Azure Face API 키
            string endpoint = "https://facelocate.cognitiveservices.azure.com/"; // Azure Face API 엔드포인트

            IFaceClient faceClient = new FaceClient(new ApiKeyServiceClientCredentials(apiKey))
            {
                Endpoint = endpoint
            };
            photo.Read(frame);
            var frameStream = frame.ToMemoryStream();
            var detectedFaces = await faceClient.Face.DetectWithStreamAsync(frameStream);
            try
            {
                int[] faceSize = new int[detectedFaces.Count]; int faceCount = 0;
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

                    if (detectedFaces.Count != 0)
                    {
                        if (faceSize[faceCount] > faceSize[MostBigFace])
                            MostBigFace = faceCount;
                    }
                    else
                    {
                        photo.Dispose();
                        frame.Dispose();
                        return "error";
                    }
                    faceCount += 1;

                }
                Console.Write(detectedFaces[MostBigFace].FaceRectangle.Top);
                try
                {
                    photo.Dispose();
                    frame.Dispose();
                    return (detectedFaces[MostBigFace].FaceRectangle.Top.ToString());
                }// - detectedFaces[MostBigFace].FaceRectangle.Height / 2)
                catch (Exception ex)
                {
                    photo.Dispose();
                    frame.Dispose();
                    return ex.Message;
                }
            }
            catch
            {
                photo.Dispose();
                frame.Dispose();
                return "재시도";
            }

        }
    }
}
