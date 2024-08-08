using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace NiggaHack.Framework.Elements
{
    public class Textures
    {
        private static GUIStyle titleStyle;
        private static GUIStyle textStyle;
        private static GUIStyle rectStyle;
        private static GUIStyle greyBackgroundStyle;

        public static Texture2D sidePannelTexture = new Texture2D(1, 1), TextBox = new Texture2D(21, 1), pageButtonTexture = new Texture2D(1, 1), pageButtonHoverTexture = new Texture2D(1, 1), buttonTexture = new Texture2D(1, 1), buttonHoverTexture = new Texture2D(1, 1), buttonClickTexture = new Texture2D(1, 1), windowTexture = new Texture2D(1, 1), boxTexture = new Texture2D(1, 1);

        private float ypos = 0;

        // Box
        private static Texture2D box = new Texture2D(1, 1);

        // Colors
        public static Color32 GreyColor = new Color32(56, 56, 57, 255);
        public static Color32 LightBlueColor = new Color32(3, 73, 252, 255);

        public static Color32 NormalButtonColor = new Color32(35, 35, 35, 255);
        public static Color32 HoveredButtonColor = new Color32(56, 56, 56, 255);
        public static Color32 ClickButtonColor = new Color32(3, 73, 232, 235);

        public static Color BackgroundColor = new Color(0.23f, 0.23f, 0.23f, 220f);

        public static Font myFont;

        public static void SetupTextures()
        {
            pageButtonHoverTexture = ApplyColorFilter(new Color32(75, 75, 75, 255));
            pageButtonTexture = ApplyColorFilter(new Color32(100, 100, 100, 255));
            buttonTexture = ApplyColorFilter(NormalButtonColor);
            buttonHoverTexture = ApplyColorFilter(HoveredButtonColor);
            buttonClickTexture = ApplyColorFilter(ClickButtonColor);
            TextBox = ApplyColorFilter(new Color32(40, 40, 41, 220));
            boxTexture = ApplyColorFilter(new Color32(40, 40, 41, 255));
            windowTexture = ApplyColorFilter(new Color32(55, 55, 55, 220));
        }

        public static void ApplyTextures()
        {
            GUI.skin.label.richText = true;
            GUI.skin.button.richText = true;
            GUI.skin.window.richText = true;
            GUI.skin.textField.richText = true;
            GUI.skin.box.richText = true;

            GUI.skin.window.border.bottom = 5;
            GUI.skin.window.border.left = 5;
            GUI.skin.window.border.top = 5;
            GUI.skin.window.border.right = 5;

            GUI.skin.window.active.background = null;
            GUI.skin.window.normal.background = null;
            GUI.skin.window.hover.background = null;
            GUI.skin.window.focused.background = null;

            GUI.skin.window.onFocused.background = null;
            GUI.skin.window.onActive.background = null;
            GUI.skin.window.onHover.background = null;
            GUI.skin.window.onNormal.background = null;

            GUI.skin.button.active.background = buttonClickTexture;
            GUI.skin.button.normal.background = buttonHoverTexture;
            GUI.skin.button.hover.background = buttonTexture;

            GUI.skin.button.onActive.background = buttonClickTexture;
            GUI.skin.button.onHover.background = buttonHoverTexture;
            GUI.skin.button.onNormal.background = buttonTexture;

            GUI.skin.box.active.background = boxTexture;
            GUI.skin.box.normal.background = boxTexture;
            GUI.skin.box.hover.background = boxTexture;

            GUI.skin.box.onActive.background = boxTexture;
            GUI.skin.box.onHover.background = boxTexture;
            GUI.skin.box.onNormal.background = boxTexture;

            GUI.skin.textField.active.background = TextBox;
            GUI.skin.textField.normal.background = TextBox;
            GUI.skin.textField.hover.background = TextBox;
            GUI.skin.textField.focused.background = TextBox;

            GUI.skin.textField.onFocused.background = TextBox;
            GUI.skin.textField.onActive.background = TextBox;
            GUI.skin.textField.onHover.background = TextBox;
            GUI.skin.textField.onNormal.background = TextBox;

            GUI.skin.textArea.active.background = TextBox;
            GUI.skin.textArea.normal.background = TextBox;
            GUI.skin.textArea.hover.background = TextBox;
            GUI.skin.textArea.focused.background = TextBox;

            GUI.skin.textArea.onFocused.background = TextBox;
            GUI.skin.textArea.onActive.background = TextBox;
            GUI.skin.textArea.onHover.background = TextBox;
            GUI.skin.textArea.onNormal.background = TextBox;

            GUI.skin.horizontalSlider.active.background = buttonTexture;
            GUI.skin.horizontalSlider.normal.background = buttonTexture;
            GUI.skin.horizontalSlider.hover.background = buttonTexture;
            GUI.skin.horizontalSlider.focused.background = buttonTexture;

            GUI.skin.horizontalSlider.onFocused.background = buttonTexture;
            GUI.skin.horizontalSlider.onActive.background = buttonTexture;
            GUI.skin.horizontalSlider.onHover.background = buttonTexture;
            GUI.skin.horizontalSlider.onNormal.background = buttonTexture;

            GUI.skin.verticalScrollbar.border = new RectOffset(0, 0, 0, 0);
            GUI.skin.verticalScrollbar.fixedWidth = 0f;
            GUI.skin.verticalScrollbar.fixedHeight = 0f;
            GUI.skin.verticalScrollbarThumb.fixedHeight = 0f;
            GUI.skin.verticalScrollbarThumb.fixedWidth = 5f;
        }


        public static Texture2D ApplyColorFilter(Color color)
        {
            Texture2D texture = new Texture2D(30, 30);

            Color[] colors = new Color[30 * 30];
            for (int i = 0; i < colors.Length; i++)
            {
                colors[i] = color;
            }
            texture.SetPixels(colors);
            texture.Apply();
            return texture;
        }

        public static void DrawText(Rect rect, string text, int fontSize = 12, Color textColor = default, FontStyle fontStyle = FontStyle.Normal, bool centerX = false, bool centerY = true)
        {
            GUIStyle _style = new GUIStyle(GUI.skin.label);
            _style.fontSize = fontSize;
            _style.font = myFont;
            _style.normal.textColor = textColor;
            float X = centerX ? rect.x + (rect.width / 2f) - (_style.CalcSize(new GUIContent(text)).x / 2f) : rect.x;
            float Y = centerY ? rect.y + (rect.height / 2f) - (_style.CalcSize(new GUIContent(text)).y / 2f) : rect.y;
            GUI.Label(new Rect(X, Y, rect.width, rect.height), new GUIContent(text), _style);
        }

        private static void DrawTexture(Rect rect, Texture2D texture, int borderRadius, Vector4 borderRadius4 = default)
        {
            if (borderRadius4 == Vector4.zero)
                borderRadius4 = new Vector4(borderRadius, borderRadius, borderRadius, borderRadius);
            GUI.DrawTexture(rect, texture, ScaleMode.StretchToFill, false, 0f, NormalButtonColor, Vector4.zero, borderRadius4);
        }

        public static Texture2D CreateRoundedTexture(int size, Color color)
        {
            Texture2D texture = new Texture2D(size, size);
            Color[] colors = new Color[size * size];
            float radius = size / 2f;
            float radiusSquared = radius * radius;

            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    float distanceSquared = (x - radius) * (x - radius) + (y - radius) * (y - radius);
                    if (distanceSquared <= radiusSquared)
                    {
                        float alpha = 1f - (distanceSquared / radiusSquared); // Smoothly fade out the edges
                        colors[y * size + x] = new Color(color.r, color.g, color.b, alpha);
                    }
                    else
                    {
                        colors[y * size + x] = Color.clear;
                    }
                }
            }

            texture.SetPixels(colors);
            texture.Apply();
            return texture;
        }
    }
}
