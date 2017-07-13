# Instructions 

1. Clone (or download and unzip) this github repo: 
https://github.com/cloudQubeTest/MVVM

2. Open "TestWPF.sln" with Visual Studio

3. Start Debugging to run the application (F5)

A couple notes:

I used Visual Studio 2015 and have not tested it with other versions. I hope no compatibility issues arise. 

I have only tested the application with ".png" images. 
".bpm" ,".jpg" and ".gif" images seem to work as well. I did not have time to thoroughly test these.

I have included some sample data to seed the database with. If you would like to start with an empty database:

Navigate to "ConnectedRepository.cs" under the "PatientsDataModel" project folder and change the "#if" blocks at the bottom. 
(Line 73 to "#if flase" and line 80 to "#if true"). Change them back before the next run to persist your own test data.
