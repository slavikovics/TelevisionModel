using TelevisionModel.Devices;
using TelevisionModel.Utils;

namespace TelevisionModelWebApp.Models;

public class ExternalDeviceModel
{
    public Device Device { get; private set; }
    
    public TechnicalSpecifications Specifications { get; private set; }

    public ExternalDeviceModel(TechnicalSpecifications specs)
    {
        Device = new Device("None");
        Specifications = specs;
    }

    public ExternalDeviceModel(string deviceName, TechnicalSpecifications specs)
    {
        Device = new Device(deviceName);
        Specifications = specs;
    }
}