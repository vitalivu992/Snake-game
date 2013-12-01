using System;

class MyPipeline: UtilMPipeline {
   public MyPipeline():base() {
       EnableGesture();
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

           if (data.label == PXCMGesture.Gesture.Label.LABEL_NAV_SWIPE_DOWN)
               Console.WriteLine("Just swipe down", data.label);
           if (data.label == PXCMGesture.Gesture.Label.LABEL_NAV_SWIPE_LEFT)
               Console.WriteLine("Just swipe left", data.label);
           if (data.label == PXCMGesture.Gesture.Label.LABEL_NAV_SWIPE_RIGHT)
               Console.WriteLine("Just swipe right", data.label);
           if (data.label == PXCMGesture.Gesture.Label.LABEL_NAV_SWIPE_UP)
               Console.WriteLine("Just swipe up", data.label);
       }
   }

   public override void OnAlert(ref PXCMGesture.Alert data)
   {
   }

   public override bool OnNewFrame() {

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