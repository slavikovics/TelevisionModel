using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TelevisionModel;
using TelevisionModel.Devices;
using TelevisionModel.Utils;
using TelevisionModelWebApp.Models;

namespace TelevisionModelWebApp.Controllers;

public class TelevisionController : Controller
{
    private readonly ILogger<TelevisionController> _logger;

    private readonly Television _television;
    
    private readonly RemoteControl _remoteControl;

    public TelevisionController(ILogger<TelevisionController> logger, Television television, RemoteControl remoteControl)
    {
        _logger = logger;
        _television = television;
        _remoteControl = remoteControl;
    }

    public IActionResult TurnOff()
    {
        if (_television.State != States.TurnedOff) _remoteControl.PowerSwitch();
        return View();
    }

    public IActionResult TurnOn()
    {
        _remoteControl.PowerSwitch();
        TempData["PreviousAction"] = "MainMenu";
        return View("MainMenu", _television.Specifications);
    }

    public IActionResult MainMenu()
    {
        _remoteControl.MainMenu();
        
        return View(_television.Specifications);
    }

    public IActionResult Next()
    {
        _remoteControl.NextChannel();

        if (_television.State == States.TelevisionBroadcasting)
        {
            BroadcastingModel broadcastingModel =
                new BroadcastingModel(_television.CurrentChannelBroadcastingSystem.SelectedChannel,
                    _television.Specifications);
            return View("TelevisionBroadcast", broadcastingModel);
        }
        
        StreamingModel streamingModel =
            new StreamingModel(_television.StreamingService.SelectedSeries, _television.Specifications);
        return View("Streaming", streamingModel);
    }
    
    public IActionResult Previous()
    {
        _remoteControl.PreviousChannel();

        if (_television.State == States.TelevisionBroadcasting)
        {
            BroadcastingModel broadcastingModel =
                new BroadcastingModel(_television.CurrentChannelBroadcastingSystem.SelectedChannel,
                    _television.Specifications);
            return View("TelevisionBroadcast", broadcastingModel);
        }
        
        StreamingModel streamingModel =
            new StreamingModel(_television.StreamingService.SelectedSeries, _television.Specifications);
        return View("Streaming", streamingModel);
    }
    
    [HttpPost]
    public IActionResult EditVolume(string newVolume, string currentView)
    {
        TempData["InfoMessage"] = _remoteControl.EditVolume(Convert.ToDouble(newVolume))?.MessageDescription;
        
        if (currentView == "TelevisionBroadcast")
        {
            BroadcastingModel broadcastingModel =
                new BroadcastingModel(_television.CurrentChannelBroadcastingSystem.SelectedChannel,
                    _television.Specifications);
            return View(currentView, broadcastingModel);
        }

        if (currentView == "Streaming")
        {
            StreamingModel streamingModel =
                new StreamingModel(_television.StreamingService.SelectedSeries, _television.Specifications);
            return View(currentView, streamingModel);
        }

        if (currentView == "Screencast")
        {
            ExternalDeviceModel externalDeviceModel = new ExternalDeviceModel(_television.Specifications);
            return View(currentView, externalDeviceModel);
        }
        
        return View(currentView, _television.Specifications);
    }
    
    [HttpPost]
    public IActionResult ChangeResolution(int resolutionX, int resolutionY)
    {
        TempData["InfoMessage"] = _remoteControl.ChangeResolution(resolutionX, resolutionY)?.MessageDescription;
        return View("MainMenu", _television.Specifications);
    }
    
    [HttpPost]
    public IActionResult UpdateSoftware(string newVersion)
    {
        TempData["InfoMessage"] = _remoteControl.UpdateSoftware(newVersion)?.MessageDescription;
        return View("MainMenu", _television.Specifications);
    }
    
    public IActionResult TelevisionBroadcast()
    {
        _remoteControl.TelevisionBroadcasting(); 
        BroadcastingModel broadcastingModel =
            new BroadcastingModel(_television.CurrentChannelBroadcastingSystem.SelectedChannel,
                _television.Specifications);
        return View(broadcastingModel);
    }
    
    public IActionResult Streaming()
    {
        _remoteControl.Streaming();
        StreamingModel model =
            new StreamingModel(_television.StreamingService.SelectedSeries, _television.Specifications);
        return View(model);
    }
    
    [HttpGet]
    public IActionResult Screencast()
    {
        ExternalDeviceModel externalDeviceModel = new ExternalDeviceModel(_television.Specifications);
        return View(externalDeviceModel);
    }

    [HttpPost]
    public IActionResult Screencast(string? newDeviceName)
    {
        if (string.IsNullOrEmpty(newDeviceName) || newDeviceName == "none" || newDeviceName == "None")
        {
            TempData["InfoMessage"] = "Cannot connect to such device";
            ExternalDeviceModel externalDevice = new ExternalDeviceModel(_television.Specifications);
            return View(externalDevice);
        }
        ExternalDeviceModel externalDeviceModel = new ExternalDeviceModel(newDeviceName, _television.Specifications);
        _remoteControl.ExternalDeviceScreencast(externalDeviceModel.Device);
        return View(externalDeviceModel);
    }

    public IActionResult Disconnect()
    {
        ExternalDeviceModel externalDeviceModel = new ExternalDeviceModel(_television.Specifications);
        return View("Screencast", externalDeviceModel);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}