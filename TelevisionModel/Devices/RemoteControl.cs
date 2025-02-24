using TelevisionModel.Data;

namespace TelevisionModel
{
    public class RemoteControl: Device
    {
        private Television PairedTelevision { get; set; }

        public delegate ActionResult PowerSwitchButton();
        
        public delegate ActionResult NextChannelButton();
        
        public delegate ActionResult PreviousChannelButton();

        public delegate ActionResult ChangeResolutionButton(int newResolutionX, int newResolutionY);
        
        public delegate ActionResult UpdateSoftwareButton(string newSoftwareVersion);
        
        public delegate ActionResult TelevisionBroadcastingButton();
        
        public delegate ActionResult StreamingButton();
        
        public delegate ActionResult MainMenuButton();
        
        public delegate ActionResult ExternalDeviceScreencastButton(Device externalDevice);
        
        public delegate ActionResult EditVolumeButton(double newVolume);
        
        public PowerSwitchButton? PowerSwitchButtonPushed;
        
        public NextChannelButton? NextChannelButtonPushed;
        
        public PreviousChannelButton? PreviousChannelButtonPushed;

        public EditVolumeButton? EditVolumeButtonPushed;
        
        public ChangeResolutionButton? ChangeResolutionButtonPushed;
        
        public UpdateSoftwareButton? UpdateSoftwareButtonPushed;
        
        public TelevisionBroadcastingButton? TelevisionBroadcastingButtonPushed;
        
        public StreamingButton? StreamingButtonPushed;
        
        public MainMenuButton? MainMenuButtonPushed;
        
        public ExternalDeviceScreencastButton? ExternalDeviceScreencastButtonPushed;
        

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

        public ActionResult? PowerSwitch()
        {
            return PowerSwitchButtonPushed?.Invoke();
        }

        public ActionResult? NextChannel()
        {
            return NextChannelButtonPushed?.Invoke();
        }

        public ActionResult? PreviousChannel()
        {
            return PreviousChannelButtonPushed?.Invoke();
        }

        public ActionResult? EditVolume(double newVolume)
        {
            return EditVolumeButtonPushed?.Invoke(newVolume);
        }
        
        public ActionResult? ChangeResolution(int newResolutionX, int newResolutionY)
        {
            return ChangeResolutionButtonPushed?.Invoke(newResolutionX, newResolutionY);
        }
        
        public ActionResult? UpdateSoftware(string newSoftwareVersion)
        {
            return UpdateSoftwareButtonPushed?.Invoke(newSoftwareVersion);
        }
        
        public ActionResult? TelevisionBroadcasting()
        {
            return TelevisionBroadcastingButtonPushed?.Invoke();
        }
        
        public ActionResult? Streaming()
        {
            return StreamingButtonPushed?.Invoke();
        }
        
        public ActionResult? MainMenu()
        {
            return MainMenuButtonPushed?.Invoke();
        }
        
        public ActionResult? ExternalDeviceScreencast(Device externalDevice)
        {
            return ExternalDeviceScreencastButtonPushed?.Invoke(externalDevice);
        }
    }
}
