using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WallColor : MonoBehaviour
{
    public Texture2D source;
    public Texture2D destination;

    void Start()
    {
        // Get a copy of the color data from the source Texture2D, in high-precision float format.
        // Each element in the array represents the color data for an individual pixel.
        int sourceMipLevel = 0;
        Color[] pixels = source.GetPixels(sourceMipLevel);

        // If required, manipulate the pixels before applying them to the destination Texture2D.
        // This example code reverses the array, which rotates the image 180 degrees.
        System.Array.Reverse(pixels, 0, pixels.Length);

        // Set the pixels of the destination Texture2D.
        int destinationMipLevel = 0;
        destination.SetPixels(pixels, destinationMipLevel);

        // Apply changes to the destination Texture2D, which uploads its data to the GPU.
        destination.Apply();
    }
}
