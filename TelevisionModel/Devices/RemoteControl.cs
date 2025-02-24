using TelevisionModel.Data;

namespace TelevisionModel
{
    public class RemoteControl: Device
    {
        private Television PairedTelevision { get; set; }

        public delegate ActionResult PowerSwitch();
        
        public delegate ActionResult NextChannel();
        
        public delegate ActionResult PreviousChannel();

        public delegate ActionResult ChangeResolution(double newResolutionX, double newResolutionY);
        
        public delegate ActionResult UpdateSoftware(string newSoftwareVersion);
        
        public delegate ActionResult TelevisionBroadcasting();
        
        public delegate ActionResult Streaming();
        
        public delegate ActionResult MainMenu();
        
        public delegate ActionResult ExternalDeviceScreencast(Device externalDevice);
        
        public delegate ActionResult EditVolume(double newVolume);
        
        public PowerSwitch PowerSwitchPushed;
        
        public NextChannel NextChannelPushed;
        
        public PreviousChannel PreviousChannelPushed;

        public EditVolume EditVolumePushed;
        
        public ChangeResolution ChangeResolutionPushed;
        
        public UpdateSoftware UpdateSoftwarePushed;
        
        public TelevisionBroadcasting TelevisionBroadcastingPushed;
        
        public Streaming StreamingPushed;
        
        public MainMenu MainMenuPushed;
        
        public ExternalDeviceScreencast ExternalDeviceScreencastPushed;
        

        public RemoteControl(Television televisionToPair, string name, string function) : base(name, function)
        {
            PairedTelevision = televisionToPair ?? throw new ArgumentException(Resources.TelevisionToPairIsNullErrorMessage);
            PairedTelevision.RegisterRemoteControl(this);
        }

        public void Pair(Television televisionToPair)
        {
            PairedTelevision.UnregisterRemoteControl(this);
            PairedTelevision = televisionToPair;
            PairedTelevision.RegisterRemoteControl(this);
        }

        public ActionResult? PushPowerSwitch()
        {
            return PowerSwitchPushed?.Invoke();
        }

        public ActionResult? PushNextChannel()
        {
            return NextChannelPushed?.Invoke();
        }

        public ActionResult? PushPreviousChannel()
        {
            return PreviousChannelPushed?.Invoke();
        }

        public ActionResult? PushEditVolume(double newVolume)
        {
            return EditVolumePushed?.Invoke(newVolume);
        }
    }
}
