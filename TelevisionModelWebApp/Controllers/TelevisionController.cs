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
        //_remoteControl.PowerSwitch();
        return View();
    }

    public IActionResult TurnOn()
    {
        _remoteControl.PowerSwitch();
        return MainMenu();
    }

    public IActionResult MainMenu()
    {
        _remoteControl.PowerSwitch();
        return View(_television.Specifications);
    }

    public IActionResult Next()
    {
        _remoteControl.NextChannel();
        return View("TelevisionBroadcast", _television.CurrentChannelBroadcastingSystem.SelectedChannel);
    }
    
    public IActionResult Previous()
    {
        _remoteControl.PreviousChannel();
        return View("TelevisionBroadcast", _television.CurrentChannelBroadcastingSystem.SelectedChannel);
    }
    
    public IActionResult EditVolume()
    {
        return View();
    }
    
    public IActionResult ChangeResolution()
    {
        return View();
    }
    
    public IActionResult UpdateSoftware()
    {
        return View();
    }
    
    public IActionResult TelevisionBroadcast()
    {
        _remoteControl.TelevisionBroadcasting(); 
        return View(_television.CurrentChannelBroadcastingSystem.SelectedChannel);
    }
    
    public IActionResult Streaming()
    {
        return View();
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