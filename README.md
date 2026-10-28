# comp graphics project
# Project Overview

This is a simple game where you run from seagulls andtry to pick up coconuts. If you get 10 coconuts, you win. If a seagull hits you, you lose.

Controls:
- WASD movement
- 1 toggle diffuse
- 2 toggle specular
- 3 toggle ambient
- 4 toggle rim light
- 5 toggle toon shader
Note all shaders toggled by number keys are on my default and only effect player model

# Burr Anderson
![water shader in shader graph](image-2.png)
- water shader, uses a cubemap with an image of the sky alongside sine waves and noise to appear as moving water
![fire shader in shader graph](image-3.png)
- fire shader, uses a sine wave to "wiggle" the fire, alongside emissions and alpha to make it emit light and translucent. 
- The colors also use a sine wave to vary along the height of the fire.

# Jacob Coleman
My shaders in order of when I made the,
Shader #1: Swaying Foliage (used on palm trees)
<img width="1421" height="867" alt="image" src="https://github.com/user-attachments/assets/bc1e0b05-2b8a-4d35-892b-9258f39d74cb" />
Shader works by shifting back and forth on x axis. However to make it feel more grounded I made the bottom stay stationary, and had a lerp function so
as the position got higher, the sway effected the model more. I then added another lerp so there could be a slider between weather it would sway in the
x or y direction. Z is the up direction on the palm tree model because I made it in blender so that's why it goes between x and y. I also added a lerp to
toggle the sway effect on and off so you could have the entire thing move instead of the top. Although i later leanrt about the branch node which would have
been smarter than lerping a boolean. I also wanted the leaves to be a little transparent so I added an alpha channel to the shader. I also used desmos to 
help me understand the math of the sine wave that moves the vertexes so I could add variable that change the speed and intensity of the sway 

Shader #2: Seagull
<img width="1212" height="685" alt="image" src="https://github.com/user-attachments/assets/a752e2da-8ee4-4255-8ef0-0dd2e727cf40" />
This was my most creative and inspired shader. I wanted to make the seagull flap its wings using a shader. My first idea was to use positional
date but I was having a hard time positioning it so I came up with a fun idea since we had just learnt about maps. I went into substance painter
and painted a map for wing displacement 

<img width="437" height="356" alt="image" src="https://github.com/user-attachments/assets/b38d10d4-9a40-475e-ad91-6d584d0f7703" />

after the map, it was as simple as adding a sin wave to make it go up an down.

Shader #3: Lighting
This one is massive so I'm gonna break down the screenshots into chuncks
<img width="1527" height="711" alt="image" src="https://github.com/user-attachments/assets/3ad5b3f9-8937-44bd-982a-cfa0920871c0" />
So first we got the diffuse and ambient. When we started this project we were using and old version of Unity so URP didn't work
so the light direction was just a vector 3 at first. Thankfully we updated and are now using URP so I was able to use the MainLightDirection
node. To make these I followed the formulas in the HLSL file we got when learning about this topic at first learning about lighting but in 
shader graph form. Light direction is also negated cause the resualts were the opposite of what they should've been at first.
<img width="1245" height="816" alt="image" src="https://github.com/user-attachments/assets/fb555643-37d2-485a-91c5-1a6d8c52d366" />
Then we have the specular and our two bonus implementations due to being a group of 3. These were more or less copies from the lecture slides
with the slight change of using the view direction node instead of any HLSL script.
<img width="880" height="737" alt="image" src="https://github.com/user-attachments/assets/bf3a5cde-0886-4b20-994c-688fe3069894" />
Finally we got the toggle section this is a long list of branches that toggle on and off different types of lighting. If something is false and
an addition, then it's 0 and if it's false and multiplication it's 1.
<img width="1065" height="727" alt="image" src="https://github.com/user-attachments/assets/0201e3ff-8fd8-4bd1-8fc5-4c0a662a0270" />
everything all together looks like this

Shader #4: Sand
<img width="1297" height="736" alt="image" src="https://github.com/user-attachments/assets/d21d76b3-5af7-4963-bbac-9a1cc4b88007" />

This one was quick a sloppy but I wanted the sand to tile and have a normal map so I just added a tiling node and a normal map sample buffer

Sahder #5: Color Grading

<img width="1917" height="925" alt="image" src="https://github.com/user-attachments/assets/ee4551c7-fd8f-4b20-aa79-e971db12314b" />

So I did 3 color grading shaders due to our group size of 3. First off is the grayscale for the player death, which was just setting saturation to zero.
I was afraid that wasn't enough so I also added a pixelation effect when you die. Which I did copy off a tutorial I found online.  The I had a brightness effect
that just adds or subtracts colour from the scene making it lighter or darker. We were gonna have this be a setting slider but ran outta time for implementation.
It does work though. Finally we have the sunset shader for winning the game. I just kida but together a bunch of simple effects I thought could look cool together.
Adding an orange tint, a paper texture off the internet, and a fade transition node which I don't really know how it works but I liked what it was doing to the scene. All of these FX are also togglable with bools like the lighting. Also because we didn't have URP until we updated the project to Unity 6, I got experience creating and setting up a renderer for a scene which was a good learning expirience.


Zehra Suleman

Initial Preposal:
https://docs.google.com/document/d/1WpICWOhZylKiqK6zDBZAsAWr7lVRbFpCSJHpwwjpjZU/edit?tab=t.0
