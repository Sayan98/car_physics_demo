using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class select : MonoBehaviour
{
    [HideInInspector]
    public int config = 0;

  public void red_default() {
      config=1;
  }

  public void green_default() {
      config=2;
  }

  public void purple_default() {
      config=3;
  }

  public void cyan_default() {
      config=4;
  }
    
}
