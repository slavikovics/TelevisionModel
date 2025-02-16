using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TelevisionModel
{
    public class Television
    {
        private SoundSystem SoundSystem { get; }

        private Screen Screen { get; }
        
        private bool IsTurnedOn { get; set; }
        
        private List<Device> ConnectedDevices { get; set; }
        
        private List<TelevisionChannel> AvailableChannels { get; set; }
        
        private int SelectedChannel { get; set; }
        
        public TechnicalSpecifications TechnicalSpecifications { get; private set; }

        public Television(SoundSystem soundSystem, Screen screen)
        {
            ConnectedDevices = new List<Device>();
            AvailableChannels = new List<TelevisionChannel>();
            IsTurnedOn = false;
            SelectedChannel = 0;
            SoundSystem = soundSystem;
            Screen = screen;
        }

        private void TurnOn()
        {
            if (IsTurnedOn)
            {
                throw new InvalidOperationException("The television is already turned on");
            }
            
            Screen.TurnOn();
            SoundSystem.TurnOn();
            IsTurnedOn = true;
        }

        private void TurnOff()
        {
            if (!IsTurnedOn)
            {
                throw new InvalidOperationException("The television is not turned on");
            }
            
            Screen.TurnOff();
            SoundSystem.TurnOff();
            IsTurnedOn = false;
        }

        public void PowerSwitchPushed()
        {
            if (IsTurnedOn) TurnOff();
            else TurnOn();
        }

        private void SelectNextChannel()
        {
            if (!IsTurnedOn) throw new InvalidOperationException("The television is not turned on");

            SelectedChannel++;
            if (SelectedChannel >= AvailableChannels.Count) SelectedChannel = 0;
        }

        private void SelectPreviousChannel()
        {
            if (!IsTurnedOn) throw new InvalidOperationException("The television is not turned on");

            SelectedChannel--;
            if (SelectedChannel < 0) SelectedChannel = AvailableChannels.Count - 1;
        }

        private void AddTelevisionChannel(string channelName, string? logoPath)
        {
            if (logoPath is null) return;
            
            foreach (TelevisionChannel channel in AvailableChannels)
            {
                if (channel.Name == channelName) throw new ArgumentException($"The television channel with the same name already exists. Name: {channelName}.");
            }
            
            TelevisionChannel televisionChannel = new TelevisionChannel(logoPath, channelName);
            AvailableChannels.Add(televisionChannel);
        }

        public void RemoveTelevisionChannel(string channelName)
        {
            TelevisionChannel? channelToRemove = AvailableChannels.Find(channel => channel.Name == channelName);
            if (channelToRemove is null) throw new ArgumentException("The television channel with this name does not exist");

            AvailableChannels.Remove(channelToRemove);
        }

        public void FindChannels()
        {
            string text = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data/logo_paths.json"));
            JsonDocument jsonDocument = JsonDocument.Parse(text);

            foreach (var property in jsonDocument.RootElement.EnumerateObject())
            {
                AddTelevisionChannel(property.Name, property.Value.GetString());
            }
        }
    }
}
