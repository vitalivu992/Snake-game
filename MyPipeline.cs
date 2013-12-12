using System;

namespace snake_game
{
    class MyPipeline : UtilMPipeline
    {
        public snake_game.MainForm formed;

        public MyPipeline(MainForm formed)
        {
            this.formed = formed;
            EnableGesture();
        }

        public MyPipeline()
            : base()
        {
            EnableGesture();
        }

        bool left = false;
        bool right = false;
        bool up = false;
        bool down = false;

        public bool getLeft()
        {
            return left;
        }

        public bool getRight()
        {
            return right;
        }

        public bool getUp()
        {
            return up;
        }
        public bool getDown()
        {
            return down;
        }
        //public override void OnGestureSetup(ref PXCMGesture.ProfileInfo profile) {}

        // sdk can recognize some predefine gesture: swipe left/top/right/down, action: wave circle, hand pose: thumb up/down victory, big5
        public override void OnGesture(ref PXCMGesture.Gesture data)
        {
            for (uint i = 0; ; i++)
            {
                // queryGestureData(user,label for body, zero based index for gesture, gesture to be return
                pxcmStatus sts = QueryGesture().QueryGestureData(0, PXCMGesture.GeoNode.Label.LABEL_ANY, i, out data);
                if (sts < pxcmStatus.PXCM_STATUS_NO_ERROR) break;
                try
                {
                    if (data.label == PXCMGesture.Gesture.Label.LABEL_NAV_SWIPE_DOWN)
                    {
                        Console.WriteLine("Just swipe down", data.label);
                        formed.config(false, false, false, true);
                        //down = true;
                        //up = false;
                        //left = false;
                        //right = false;
                        //Environment.Exit(0);
                        //break;
                    }
                    //Console.WriteLine("Just swipe down", data.label);
                    if (data.label == PXCMGesture.Gesture.Label.LABEL_NAV_SWIPE_LEFT)
                    {
                        Console.WriteLine("Just swipe left", data.label);
                        formed.config(true, false, false, false);

                        //down = false;
                        //up = false;
                        //left = true;
                        //right = false;
                        //break;
                    }
                    // Console.WriteLine("Just swipe left", data.label);
                    if (data.label == PXCMGesture.Gesture.Label.LABEL_NAV_SWIPE_RIGHT)
                    {
                        Console.WriteLine("Just swipe right", data.label);

                        formed.config(false, true, false, false);

                        //down = false;
                        //up = false;
                        //left = false;
                        //right = true;
                        //break;
                    }
                    // Console.WriteLine("Just swipe right", data.label);
                    if (data.label == PXCMGesture.Gesture.Label.LABEL_NAV_SWIPE_UP)
                    {
                        Console.WriteLine("Just swipe up", data.label);

                        formed.config(false, false, true, false);
                        //down = false;
                        //up = true;
                        //left = false;
                        //right = false;
                        //break;
                    }
                    //Console.WriteLine("Just swipe up", data.label);
                }
                catch (NullReferenceException e)
                {
                    
                }
                
            }
        }

        public override void OnAlert(ref PXCMGesture.Alert data)
        {
        }

        public override bool OnNewFrame()
        {

            /* Retrieve individual node data */
            PXCMGesture.GeoNode thumb_data;
            //gesture.
            QueryGesture().QueryNodeData(0, PXCMGesture.GeoNode.Label.LABEL_BODY_HAND_PRIMARY | PXCMGesture.GeoNode.Label.LABEL_FINGER_THUMB, out thumb_data);

            /* Retrieve data of all five fingers in a single call */
            PXCMGesture.GeoNode[] hand_data = new PXCMGesture.GeoNode[5];
            //gesture.
            QueryGesture().QueryNodeData(0, PXCMGesture.GeoNode.Label.LABEL_BODY_HAND_PRIMARY | PXCMGesture.GeoNode.Label.LABEL_FINGER_THUMB, hand_data);
            return true;

        }

    }
}