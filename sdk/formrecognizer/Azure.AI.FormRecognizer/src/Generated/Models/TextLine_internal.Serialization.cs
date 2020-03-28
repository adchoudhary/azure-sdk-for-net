// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.AI.FormRecognizer.Models
{
    internal partial class TextLine_internal
    {
        internal static TextLine_internal DeserializeTextLine_internal(JsonElement element)
        {
            string text = default;
            IReadOnlyList<float> boundingBox = default;
            Language_internal? language = default;
            IReadOnlyList<TextWord_internal> words = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("text"))
                {
                    text = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("boundingBox"))
                {
                    List<float> array = new List<float>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetSingle());
                    }
                    boundingBox = array;
                    continue;
                }
                if (property.NameEquals("language"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    language = new Language_internal(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("words"))
                {
                    List<TextWord_internal> array = new List<TextWord_internal>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(TextWord_internal.DeserializeTextWord_internal(item));
                    }
                    words = array;
                    continue;
                }
            }
            return new TextLine_internal(text, boundingBox, language, words);
        }
    }
}
