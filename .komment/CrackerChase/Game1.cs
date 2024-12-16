{"name":"Game1.cs","path":"CrackerChase/Game1.cs","content":{"structured":{"description":"","image":"<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"no\"?>\n<!DOCTYPE svg PUBLIC \"-//W3C//DTD SVG 1.1//EN\"\n \"http://www.w3.org/Graphics/SVG/1.1/DTD/svg11.dtd\">\n<!-- Generated by graphviz version 2.43.0 (0)\n -->\n<!-- Title: CrackerChase.Game1 Pages: 1 -->\n<svg width=\"130pt\" height=\"82pt\"\n viewBox=\"0.00 0.00 130.00 82.00\" xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\">\n<g id=\"graph0\" class=\"graph\" transform=\"scale(1 1) rotate(0) translate(4 78)\">\n<title>CrackerChase.Game1</title>\n<!-- Node1 -->\n<g id=\"Node000001\" class=\"node\">\n<title>Node1</title>\n<g id=\"a_Node000001\"><a xlink:title=\" \">\n<polygon fill=\"#999999\" stroke=\"#666666\" points=\"122,-19 0,-19 0,0 122,0 122,-19\"/>\n<text text-anchor=\"middle\" x=\"61\" y=\"-7\" font-family=\"Helvetica,sans-Serif\" font-size=\"10.00\">CrackerChase.Game1</text>\n</a>\n</g>\n</g>\n<!-- Node2 -->\n<g id=\"Node000002\" class=\"node\">\n<title>Node2</title>\n<g id=\"a_Node000002\"><a xlink:title=\" \">\n<polygon fill=\"white\" stroke=\"#666666\" points=\"84,-74 38,-74 38,-55 84,-55 84,-74\"/>\n<text text-anchor=\"middle\" x=\"61\" y=\"-62\" font-family=\"Helvetica,sans-Serif\" font-size=\"10.00\">Game</text>\n</a>\n</g>\n</g>\n<!-- Node2&#45;&gt;Node1 -->\n<g id=\"edge1_Node000001_Node000002\" class=\"edge\">\n<title>Node2&#45;&gt;Node1</title>\n<g id=\"a_edge1_Node000001_Node000002\"><a xlink:title=\" \">\n<path fill=\"none\" stroke=\"#63b8ff\" d=\"M61,-44.66C61,-35.93 61,-25.99 61,-19.09\"/>\n<polygon fill=\"#63b8ff\" stroke=\"#63b8ff\" points=\"57.5,-44.75 61,-54.75 64.5,-44.75 57.5,-44.75\"/>\n</a>\n</g>\n</g>\n</g>\n</svg>\n","items":[{"id":"1d0e1233-2b1d-485a-8839-e9943fc78b25","ancestors":[],"type":"function","name":"startPlayingGame","location":{"offset":" ","indent":8,"insert":35,"start":35},"returns":null,"params":[],"code":"void startPlayingGame()\n        {\n            foreach (Sprite s in gameSprites)\n            {\n                s.Reset();\n            }\n            foreach (Target t in crackers)\n            {\n                t.Reset();\n            }\n            messageString = \"Cracker Chase\";\n\n            playing = true;\n            timer = 600;\n            score = 0;\n        }","skip":false,"length":16,"comment":{"description":"Reset's all sprites and targets, sets the game title and timer, initializes the score, and activates the game mode.","params":[],"returns":null}},{"id":"2817d687-7f9c-4536-ad2f-0cf7dc810d93","ancestors":[],"type":"function","name":"Initialize","location":{"offset":" ","indent":8,"insert":58,"start":58},"returns":null,"params":[],"code":"protected override void Initialize()\n        {\n            base.Initialize();\n        }","skip":false,"length":4,"comment":{"description":"initializes the class by performing any necessary setup or configuration.","params":[],"returns":null}},{"id":"12875956-1b6d-4427-9c69-b00d44daa3f0","ancestors":[],"type":"function","name":"LoadContent","location":{"offset":" ","indent":8,"insert":63,"start":63},"returns":null,"params":[],"code":"protected override void LoadContent()\n        {\n            // Create a new SpriteBatch, which can be used to draw textures.\n            spriteBatch = new SpriteBatch(GraphicsDevice);\n\n            messageFont = Content.Load<SpriteFont>(\"MessageFont\");\n\n            screenWidth = GraphicsDevice.Viewport.Width;\n            screenHeight = GraphicsDevice.Viewport.Height;\n\n            Texture2D cheeseTexture = Content.Load<Texture2D>(\"cheese\");\n            Texture2D cloth = Content.Load<Texture2D>(\"Tablecloth\");\n            Texture2D crackerTexture = Content.Load<Texture2D>(\"cracker\");\n\n            BurpSound = Content.Load<SoundEffect>(\"Burp\");\n\n            background = new Sprite(screenWidth, screenHeight, cloth, screenWidth, 0, 0);\n            gameSprites.Add(background);\n\n            int crackerWidth = screenWidth / 20;\n\n            for (int i = 0; i < 100; i++)\n            {\n                cracker = new Target(screenWidth, screenHeight, crackerTexture, crackerWidth, 0, 0);\n                gameSprites.Add(cracker);\n                crackers.Add(cracker);\n            }\n\n            int cheeseWidth = screenWidth / 15;\n            cheese = new Mover(screenWidth, screenHeight, cheeseTexture, cheeseWidth, screenWidth / 2, screenHeight / 2, 500, 500);\n            gameSprites.Add(cheese);\n\n            // go to the start screen state\n            startPlayingGame();\n        }","skip":false,"length":35,"comment":{"description":"loads content for the game, including sprites, fonts, and sounds. It creates a SpriteBatch, loads textures for cheese, cloth, and cracker, and adds them to the gameSprites list. Additionally, it creates a Mover object for the cheese and adds it to the gameSprites list.","params":[],"returns":null}},{"id":"96483548-efe3-4b03-a2a1-e9382c7bdfb6","ancestors":[],"type":"function","name":"UnloadContent","location":{"offset":" ","indent":8,"insert":99,"start":99},"returns":null,"params":[],"code":"protected override void UnloadContent()\n        {\n            // TODO: Unload any non ContentManager content here\n        }","skip":false,"length":4,"comment":{"description":"is intended to unload any non-ContentManager content during application shutdown.","params":[],"returns":null}}]}}}