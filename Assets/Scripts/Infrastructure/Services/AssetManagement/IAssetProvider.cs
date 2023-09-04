using UnityEngine;

namespace Infrastructure.Services
{
    public interface IAssetProvider : IService
    {
        public void Init();
        public GameObject Instantiate(string path, Vector3 at);

        public GameObject Instantiate(string path);
        public GameObject Instantiate(string path, Transform parent);
    }
}