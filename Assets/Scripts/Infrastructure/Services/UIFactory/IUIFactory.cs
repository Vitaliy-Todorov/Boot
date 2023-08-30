using System.Collections.Generic;
using Data;
using Entities;
using UI;
using UnityEngine;

namespace Infrastructure.Services
{
    public interface IUIFactory : IService
    {
        public TMenu CreateUiElement<TMenu>(string path) where TMenu : IUiElement;
    }
}