using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TelevisionModel;
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
        TempData["PreviousAction"] = ControllerContext.ActionDescriptor.ActionName;
        return View(_television.Specifications);
    }

    public IActionResult Next()
    {
        _remoteControl.NextChannel();
        if (_television.State == States.TelevisionBroadcasting) return View("TelevisionBroadcast", _television.CurrentChannelBroadcastingSystem.SelectedChannel);
        return View("Streaming", _television.StreamingService.SelectedSeries);
    }
    
    public IActionResult Previous()
    {
        _remoteControl.PreviousChannel();
        if (_television.State == States.TelevisionBroadcasting) return View("TelevisionBroadcast", _television.CurrentChannelBroadcastingSystem.SelectedChannel);
        return View("Streaming", _television.StreamingService.SelectedSeries);
    }
    
    [HttpPost]
    public IActionResult EditVolume(string newVolume)
    {
        TempData["InfoMessage"] = _remoteControl.EditVolume(Convert.ToDouble(newVolume))?.MessageDescription;
        return View("MainMenu", _television.Specifications);
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
        return View(_television.CurrentChannelBroadcastingSystem.SelectedChannel);
    }
    
    public IActionResult Streaming()
    {
        _remoteControl.Streaming();
        return View(_television.StreamingService.SelectedSeries);
    }
    
    public IActionResult ScreencastFromExternalDevice()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}