# Music Bank
This is a ASP.NET web app that enables a record label to manage their artists, albums, and tracks.
This app is enhanced to support security concepts as well as data such as rich text and media files (images, audio files, and videos).

## Security Concepts
This app allow users to register and login as different roles. Each role has different authority to manage the database on website.

## Before login
Only home page is avilable before login as any role.
![](https://github.com/yhao18/ASP.NET-MusicBank/assets/71744660/141c13a7-02f3-4063-860d-65c9a441c0d8)

User can register as different role at the register page
![image](https://github.com/yhao18/ASP.NET-MusicBank/assets/71744660/2a2c0c62-5486-4f49-83ab-c3e9a61b7156)

   
## After login
After login, the link of Artists, Albums and Tracks list will appear on the navbar.
#### If user login as a normal staff,  user can browse information about all the Artists, Albums and Tracks, but no edition is avilable.
![image](https://github.com/yhao18/ASP.NET-MusicBank/assets/71744660/24a89cb6-aa13-4a9b-bcb0-e15395d4a204) 
![image](https://github.com/yhao18/ASP.NET-MusicBank/assets/71744660/9c776a30-b1cb-478f-bf67-a13c8a2f9e03)
![image](https://github.com/yhao18/ASP.NET-MusicBank/assets/71744660/93009191-5fe3-4219-9523-873ef74b1b0e)

And also the detail of each item in the list will be displayed later.
### If User loging as Clerk, user can manage tracks by adding track to an album
![image](https://github.com/yhao18/ASP.NET-MusicBank/assets/71744660/99dd034a-6731-4c99-b638-9d658811dc8d)

And delete or eidit is avilable at track list page when loging as a Clerk
![image](https://github.com/yhao18/ASP.NET-MusicBank/assets/71744660/dcbffee6-5222-451b-8837-1b7476892fe6)

Clerk can view Artist list and detail, but no authrity to make change to artists.
![image](https://github.com/yhao18/ASP.NET-MusicBank/assets/71744660/0c9b05ca-a7d0-4aa5-ac91-19ea4c5145c2)


### If user login as role of Coordinator, user can add related Album and media files to the artist, but can not make changes to tracks
![image](https://github.com/yhao18/ASP.NET-MusicBank/assets/71744660/61113642-8a94-4fa6-95d2-e70f7b875d54)















