﻿namespace Infrastructure.Services;

public class NotFoundListener
{
    public  Action OnNotFound { get;set; }

    public void NotifyNotFound()
    {
        if(NotifyNotFound != null)
        {
            OnNotFound.Invoke();
        }
    }

}