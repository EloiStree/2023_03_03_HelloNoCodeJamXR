# Hello No Code Jam XR

This project is a demo of how you can create from A-z a game for Quest 2 without code.  

This project is done under Unity.
I am recording all the step to create it to remember what need to be learn and done from someone that start in XR in 2023.

You can download the code here:    
https://github.com/EloiStree/2023_03_03_HelloNoCodeJamXR  
`git clone https://github.com/EloiStree/2023_03_03_HelloNoCodeJamXR.git`

Download the last version of the project here for Quest 2:  
https://github.com/EloiStree/2023_03_03_HelloNoCodeJamXR/releases   
   
Read the wiki to follow the workshop:  
https://github.com/EloiStree/2023_03_03_HelloNoCodeJamXR/wiki   

Ask any questions on the workshop:  
https://github.com/EloiStree/2023_03_03_HelloNoCodeJamXR/issues  

##  🚧 Video introduction 🚧

Will be add soon

## Language

FR: La majeur partie des tutorials est en Anglais car mon cerveaux change automatiquement à l'anglais sans m'en rendre compte par défaut.
Mais comme je vie en Belgique des parties du cours seront en français.

EN: Most of the tutorials is in english because my bain is switching all the time to english by default.
But as I live in Belgium some parts will be in French.


FR: Pourquoi en Anglais ? Il faut comprendre que 95% de la documentation, des tutorials, des interfaces, des personnes avec qui vous allez communiquer sont en anglais.
Donner le cours en Francais vocalement est nécessaire en classe pour que la matière soit bien comprise. Mais vouloir travailler dans le milieu sans apprendre l'anglais est un grave erreur. Je vous invite fortement à commencer dès maintenant à étudier progressivement l'anglais si vous désirez travailler dans le milieu.



## For this workshop you will need to download

- Unity 2021.3.19f1 (Engine)  
  - https://unity.com/releases/editor/archive at Unity 2021.3.19 in Unity 2021.X  

[![image](https://user-images.githubusercontent.com/20149493/223064038-af071c06-b5b9-4e1b-bd40-fef4fd792c76.png)]()


Blender(3D) https://www.blender.org   (If you do/manipulate 3D)
[![image](https://user-images.githubusercontent.com/20149493/223063725-8df5abe5-b449-45fa-a60c-531f57a87b32.png)](https://www.blender.org)  


Krita(2D) https://krita.org/fr/     (If you do/manipulate 2D)
 [![image](https://user-images.githubusercontent.com/20149493/223063593-27ef72f6-0633-4792-bfd8-8d12b1385af0.png)](https://krita.org/fr/)  


Oculus Setup from Meta (VR PC) [https://www.meta.com/be/en/quest/setup/](https://www.meta.com/be/en/quest/setup/)  (If you run VR on your PC)
[![image](https://user-images.githubusercontent.com/20149493/223070474-27cbf38e-0018-4816-b74a-63868d29e40a.png)](https://www.meta.com/be/en/quest/setup/)


SideQuest (VR Android) https://sidequestvr.com/setup-howto  (If you want to install app on the Quest)
[![image](https://user-images.githubusercontent.com/20149493/223070733-b1ba7f2a-e794-4ca2-be0e-4865e0d4e863.png)](https://sidequestvr.com/setup-howto)

Audacity (Audio) https://www.audacityteam.org    (If you insert sound in you application)
[![image](https://user-images.githubusercontent.com/20149493/223726963-864aaf8f-9b03-4d23-8239-e0458aad14d3.png)](https://www.audacityteam.org/download/)  


You need thoes driver if you want your phone or Quest to be well detected by Window:
- Google USB Driver: https://developer.android.com/studio/run/win-usb
- Quest ADB driver: https://developer.oculus.com/downloads/package/oculus-adb-drivers/


Also good to download:
 - Steam VR: https://store.steampowered.com/steamvr?l=french  (To play at VR game not on Oculus Setup)
 - ALVR: https://alvr-org.github.io  (To stream your SteamVR game by wifi on the Quest)
 - Virtual Desktop: https://www.vrdesktop.net (20€) (to Stream your Steam VR game by WiFi with no-geek interface)
 - Developer Oculus Hub: https://developer.oculus.com/downloads/package/oculus-developer-hub-win/ (If you need debugging tool for VR)


Where to learn Unity 3D by myself ?
- [Unity Learn on official website](https://learn.unity.com/?_gl=1%2Ah530y3%2A_gcl_aw%2AR0NMLjE2MzY3MTY5ODMuQ2p3S0NBaUF2cmlNQmhBdUVpd0E4Q3M1bGFJenM2UXZhV2RxendXU3cwSUlFN3ZYLXBrLTgySU50QWRTTk5acEl4dThCUGZPMnBFeTFSb0M5ZDhRQXZEX0J3RQ..%2A_gcl_dc%2AR0NMLjE2MzY3MTY5ODMuQ2p3S0NBaUF2cmlNQmhBdUVpd0E4Q3M1bGFJenM2UXZhV2RxendXU3cwSUlFN3ZYLXBrLTgySU50QWRTTk5acEl4dThCUGZPMnBFeTFSb0M5ZDhRQXZEX0J3RQ..&_ga=2.182193959.1225568882.1643885899-337911776.1601136010) [Unity learn C#](https://unity.com/how-to/learning-c-sharp-unity-beginners)
- Yotube: [Unity Beginner](https://www.youtube.com/results?search_query=unity+begginner+) [Learn C#](https://www.youtube.com/results?search_query=c%23) [Unity FR](https://www.youtube.com/results?search_query=unity+fr)
  - Famous Youtuber on the topic: 
    - https://www.youtube.com/@CodeMonkeyUnity Beginner and amazing project
    - https://www.youtube.com/@Brackeys Beginner and Advance but amazing video
    - https://www.youtube.com/@dilmerv Best tutorial on VR and Open XR
    - https://www.youtube.com/@ArnaudJopart FR Très bonne vidéo qui prend le temps d'aller loin.
    - https://www.youtube.com/@Acegikmo Advance and technicial but quiete and precise
- Udemy: [Unity](https://www.udemy.com/courses/search/?src=ukw&q=unity) - [C#](https://www.udemy.com/courses/search/?src=ukw&q=c%23)  
- Eloi Previous workshop: https://github.com/EloiStree/2023_03_03_HelloNoCodeJamXR/wiki/PreviousWorkshopFR

Unity Learn through Unity Hub : [Unity Essential](https://learn.unity.com/tutorial/welcome-to-unity-essentials)   
![image](https://user-images.githubusercontent.com/20149493/223066437-deaf55e5-d250-4554-ac96-79d9a9bec0df.png)  

C# and Unity Certification:
[Google sheet document with topic to learn](https://docs.google.com/spreadsheets/d/1TI_-X7T4Dh67LKkINNmpfvuofxn3RCUhHVNInaRRUsw/edit?usp=sharing) 
[![image](https://user-images.githubusercontent.com/20149493/223106895-b2290e6e-4754-49ad-b699-cb5493a41e2b.png)](https://docs.google.com/spreadsheets/d/1TI_-X7T4Dh67LKkINNmpfvuofxn3RCUhHVNInaRRUsw/edit?usp=sharing)



# 1 + 2 hours introduction

## Introduction to VR

[+- 1 hour Slides introduction](https://docs.google.com/presentation/d/e/2PACX-1vT_HmuzmQK3AlM6KNq14JdXQP-SETJ-OsYLxeamX-At5SODFE61qWTvtJ8TOcXzE4MzQPXhtwNekqru/pub?start=false&loop=false&delayms=3000)
[![image](https://user-images.githubusercontent.com/20149493/223083199-fe6b6c23-1dc5-48ab-a47f-a63a35ede3f8.png)](https://docs.google.com/presentation/d/e/2PACX-1vT_HmuzmQK3AlM6KNq14JdXQP-SETJ-OsYLxeamX-At5SODFE61qWTvtJ8TOcXzE4MzQPXhtwNekqru/pub?start=false&loop=false&delayms=3000)

## Introduction to Unity and OpenXR

[![thumbnail](https://user-images.githubusercontent.com/20149493/223084781-71bc7925-aab1-4012-ac4c-8b94941600eb.png)](https://youtu.be/LcTtWlOoKAs)  
[Video (No talk)](https://youtu.be/LcTtWlOoKAs) : https://youtu.be/LcTtWlOoKAs

## Cool video

 [VR 1 ?](https://www.youtube.com/watch?v=wRCS2-AAyNM&ab_channel=ÉloiStrée%2Cꬲ🧰%3ARawvideo)  | [VR 2 ?](https://www.youtube.com/watch?v=8rVnkWbLnk8&ab_channel=ÉloiStrée%2Cꬲ🧰%3ARawvideo)  | [Painting Jam](https://www.youtube.com/watch?v=n6uqpYgrE2E&ab_channel=JamsCenter)  
---|---|---  
 [![image](https://user-images.githubusercontent.com/20149493/225070588-5184e434-8ffc-4896-9bcf-35c64c79f666.png)](https://www.youtube.com/watch?v=wRCS2-AAyNM&ab_channel=ÉloiStrée%2Cꬲ🧰%3ARawvideo)  | [![image](https://user-images.githubusercontent.com/20149493/225070647-1dd3387e-b85d-4f37-ae27-b2c30cb2d832.png)](https://www.youtube.com/watch?v=8rVnkWbLnk8&ab_channel=ÉloiStrée%2Cꬲ🧰%3ARawvideo)  |  [![image](https://user-images.githubusercontent.com/20149493/225071212-4c1f51fc-45c1-48dc-b9a3-b3a7173a4d44.png)](https://www.youtube.com/watch?v=n6uqpYgrE2E&ab_channel=JamsCenter)





# Note: RTFM & LMGTFY & Chat GPT

Just a reminder that your best friend is:
- RTFM: Read the fucking manual
- LMGTFY: Let's me google that for you
- Chat GPT: Asking what you should learn next, take the keyword and do more research


[RTFM](https://www.google.com/search?client=opera-gx&q=rtfm&sourceid=opera&ie=UTF-8&oe=UTF-8) | [LMGTFY](https://letmegooglethat.com)  | [ChatGPT](https://www.youtube.com/@Underscore_/search?query=chat) 
---|---|---  
[![image](https://user-images.githubusercontent.com/20149493/223086838-1f3c859b-07d7-4f85-b33b-a58ce554f0a5.png)](https://www.google.com/search?client=opera-gx&q=rtfm&sourceid=opera&ie=UTF-8&oe=UTF-8) | [![image](https://user-images.githubusercontent.com/20149493/223086924-6db3feed-d03b-474c-8326-411602672f36.png)](https://letmegooglethat.com) | [![image](https://user-images.githubusercontent.com/20149493/223087025-0fc8f7fe-617d-4160-859b-aa406625c859.png)](https://www.youtube.com/@Underscore_/search?query=chat)   
 Read the fucking manual | Let's me google that for you | Just ask what you should learn next.  



# Cool full tutorial found

- Quick and direct text tutorial on how to setup the Quest for a first scene in Oculus Quest 2
  - https://dev.to/kauresss/vr-lessons-for-newbies-42a2


