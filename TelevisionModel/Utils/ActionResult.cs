﻿namespace TelevisionModel.Utils;

public class ActionResult
{
    public List<string> MessageDetails { get; private set; }
    
    public string MessageDescription { get; set; }  

    public ActionResult(string messageDescription)
    {
        MessageDescription = messageDescription;
        MessageDetails = new List<string>();
    }

    public override string ToString()
    {
        string result = MessageDescription;
        foreach (string messageDetail in MessageDetails) result += "\n" + messageDetail;
        return result;
    }

    public ActionResult AddSpecifications(TechnicalSpecifications technicalSpecifications)
    {
        MessageDetails.Add(technicalSpecifications.ToString());
        return this;
    }
}