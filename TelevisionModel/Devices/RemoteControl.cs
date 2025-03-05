using TelevisionModel.Data;
using TelevisionModel.Devices;
using TelevisionModel.Utils;

namespace TelevisionModel
{
    public class RemoteControl: Device
    {
        private Television PairedTelevision { get; set; }

        public delegate ActionResult ZeroArgumentsButton();

        public delegate ActionResult ChangeResolutionButton(int newResolutionX, int newResolutionY);
        
        public delegate ActionResult UpdateSoftwareButton(string newSoftwareVersion);
        
        public delegate ActionResult ExternalDeviceScreencastButton(Device externalDevice);
        
        public delegate ActionResult EditVolumeButton(double newVolume);
        
        public ZeroArgumentsButton? PowerSwitchButtonPushed;
        
        public ZeroArgumentsButton? NextChannelButtonPushed;
        
        public ZeroArgumentsButton? PreviousChannelButtonPushed;

        public EditVolumeButton? EditVolumeButtonPushed;
        
        public ChangeResolutionButton? ChangeResolutionButtonPushed;
        
        public UpdateSoftwareButton? UpdateSoftwareButtonPushed;
        
        public ZeroArgumentsButton? TelevisionBroadcastingButtonPushed;
        
        public ZeroArgumentsButton? StreamingButtonPushed;
        
        public ZeroArgumentsButton? MainMenuButtonPushed;
        
        public ExternalDeviceScreencastButton? ExternalDeviceScreencastButtonPushed;
        
        public RemoteControl(Television televisionToPair, string name = "") : base(name)
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
