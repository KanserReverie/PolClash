using System.Text.RegularExpressions;
#if UNITY_EDITOR
using UnityEditor.U2D.Sprites;
using UnityEditor;
using UnityEngine;
#endif
using System.Linq;

public static class Texture2DExtensions
{

#if UNITY_EDITOR
    public static void CopyMetadata(this Texture2D source, Texture2D destination)
    {
        // Create Data Provider for destination texture
        var destinationFactory = new SpriteDataProviderFactories();
        destinationFactory.Init();
        var destinationDataProvider = destinationFactory.GetSpriteEditorDataProviderFromObject(destination);
        destinationDataProvider.InitSpriteEditorDataProvider();

        // Create Data Provider for source texture
        var sourceFactory = new SpriteDataProviderFactories();
        sourceFactory.Init();
        var sourceDataProvider = sourceFactory.GetSpriteEditorDataProviderFromObject(source);
        sourceDataProvider.InitSpriteEditorDataProvider();

        // Get sprite rects of the source
        var spriteRects = sourceDataProvider.GetSpriteRects();

        // Get Name-FileID pairs of the source
        var sourceNameFileIdDataProvider = sourceDataProvider.GetDataProvider<ISpriteNameFileIdDataProvider>();
        var pairs = sourceNameFileIdDataProvider.GetNameFileIdPairs();

        // Update names and pairs
        foreach (var rect in spriteRects)
        {
            // If the original naming convention of each rect is of the format <name>_<index>
            // then we want keep the suffix <index>, and replace the prefix <name>. Otherwise,
            // generate a random <index>.
            Regex rx = new Regex(@"(?<prefix>.*)_(?<suffix>.*)");
            Match match = rx.Match(rect.name);
            string newName;
            if (match.Success)
            {
                newName = $"{destination.name}_{match.Groups["suffix"].Value}";
            }
            else
            {
                newName = $"{destination.name}_{GUID.Generate()}";
            }

            // Update the pair corresponding to this rect
            SpriteNameFileIdPair pair = pairs.FirstOrDefault(pair => pair.GetFileGUID() == rect.spriteID);
            pair.name = newName;

            // Update name of rect
            rect.name = newName;
        }

        // Set sprite rects 
        destinationDataProvider.SetSpriteRects(spriteRects.ToArray());

        // Set name file id pairs
        var textureNameFileIdDataProvider = destinationDataProvider.GetDataProvider<ISpriteNameFileIdDataProvider>();
        textureNameFileIdDataProvider.SetNameFileIdPairs(pairs);

        // Apply and save
        destinationDataProvider.Apply();
        var assetImporter = destinationDataProvider.targetObject as AssetImporter;
        assetImporter.SaveAndReimport();
    }
#endif

}
