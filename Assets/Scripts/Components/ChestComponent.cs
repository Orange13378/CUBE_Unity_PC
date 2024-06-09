using System.Collections.Generic;
using UnityEngine;

namespace CubeECS
{
    public struct ChestComponent
    {
        public List<ChestItem> Items;
        public GameObject CurrentOpenedItem;
    }
}