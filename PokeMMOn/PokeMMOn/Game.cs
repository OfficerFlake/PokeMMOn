using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace PokeMMOn
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public partial class Game : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public static TileSet Tiles32x32 = null;
        public static TileSet Tiles16x16 = null;
        public static List<Layer> Layers = null;
        public static Layer Layer32 = null;
        public static Layer Layer16 = null;

        public Game()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 1024;
            graphics.PreferredBackBufferWidth = 1024;
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Tiles32x32 = new TileSet(GraphicsDevice, @".\Tiles\32.png", 32, 32);
            Tiles16x16 = new TileSet(GraphicsDevice, @".\Tiles\16.png", 16, 16);

            Layers = new List<Layer>();
            Layer Layer32 = new Layer();
            Layer32.Loadt32(@".\Maps\rm_test\tiles.t32");
            Layers.Add(Layer32);
            Layer Layer16 = new Layer();
            Layer16.Loadt16(@".\Maps\rm_test\tiles.t16");
            Layers.Add(Layer16);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            foreach (Layer thislayer in Layers)
            {
                foreach (Tile thistile in thislayer.tiles)
                {
                    spriteBatch.Draw(thistile.texture, new Rectangle(thistile.X * thislayer.tileWidth, thistile.Y * thislayer.tileHeight, thislayer.tileWidth, thislayer.tileHeight), thistile.GetTile(), Color.White);
                }
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
