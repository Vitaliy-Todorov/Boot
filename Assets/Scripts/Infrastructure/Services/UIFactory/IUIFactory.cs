using System.Collections.Generic;
using Data;
using Entities;
using UI;
using UnityEngine;

namespace Infrastructure.Services
{
    public interface IUIFactory : IService
    {
        public void Init(GameManager gameManager, IAssetProvider assetProvider);
        public TMenu CreateUiElement<TMenu>(string path) where TMenu : IUiElement;
    }
}