# SheepyAutoSplitter

## Overview
SheepyAutoSplitter is a tool designed to help speedrunners automatically split the time at predefined checkpoints (splits) during a race of Sheepy A Short Adventure. It allows players to focus on the game without worrying about manually recording times.

## Who Am I?
I am GatoNáutica, a beginner multimedia developer passionate about video games and programming. I enjoy creating and exploring new ideas in my free time, always looking to have fun and have a good time.

Why Did I Make It?
At first, I didn't have this in mind. The idea came after trying to do my first speedrun and uploading it to the page before reading the forum. It was then that I realized the game didn't have support for autosplitter, which distracted me a lot from having to do the splits manually (and also because I was too lazy to do it).

So, one night on December 8th at 3:09 a.m., while I couldn't sleep, I decided to start this project. Here is the result. It’s the first time I've done something like this, so it may have errors or could be improved in a better way. Since I don't have much knowledge in these topics, I initially tried using Cheat Engine, but it didn't work; I never knew exactly what to do.

## How Does the Code Work?
The autosplitter works by capturing the game's screen and analyzing the content to identify when checkpoints are reached. It uses image processing techniques to detect black screens and verify reference images. It is also programmed to avoid false positives in certain areas or when performing certain actions.

According to the run rules, it is only valid and ends on the first black screen after finishing chapter 6, right before the credits. Therefore, the code analyzes black screens when moving from one chapter to another to make the splits more precisely.

Actions such as losing or opening the game menu, which generate black-toned screens and could cause false positives, are fully managed. I made sure that each action that generates an unwanted black screen is not detected to avoid errors.

## Functions Implemented in the Code
1. **Screen Capture**:

The code uses the OpenCvSharp library to capture the game's screen. The CaptureFullScreen function takes a full screenshot and converts it into an image matrix (Mat).

2. **Black Screen Detection**:

The IsBlackScreen function converts the screenshot to grayscale and calculates the image histogram. If the percentage of black pixels or dark tones exceeds a specific threshold, it is considered a black screen.

3. **Reference Image Verification**:

The autosplitter compares the current screenshot with the reference images (end.png) of each chapter using the IsMatch function. This function converts both images to grayscale and uses template matching technique to determine the level of match.

4. **Exclusion of Unwanted Images**:

To avoid false positives, the code also verifies if the screenshot matches any of the exclusion images (noSplit1.png, noSplit2.png, etc.). If there is a match, the black screen is ignored.

5. **Autosplitter Execution**:

The StartSplitting function is the heart of the autosplitter. It continuously captures the screen, checks if it is a black screen, and verifies matches with the reference and exclusion images. When a valid split is detected, the time is recorded, and it moves to the next checkpoint.

6. **Image Configuration**:

The reference images (end.png) and exclusion images (noSplit1.png, noSplit2.png) must be placed in the appropriate folders for the autosplitter to work correctly. Universal images like start.png and menu.png are also essential to support detection.

## Correct Use of the Autosplitter
1. **Installation**: Follow the instructions in the `INSTALL.md` file to set up all dependencies and prepare the environment.

2. **Execution**: Run the autosplitter from Visual Studio. Preferably as an administrator.

3. **Configuration**: Customize the reference images and exclusion images to suit your specific run. Example: C:\Users\Your User\OneDrive\Desktop\AutoSplitter-Sheepy A Short Adventure

## README_LANGUAGES.md?
Here you will find all the messages displayed in the code and terminal. Only for people who do not speak Spanish.

## Contributions
Contributions are welcome and appreciated! If you have ideas, improvements, or find any issues, feel free to collaborate on the project. Here are some ways to contribute:

1. **Report Issues**: If you find any bugs or have trouble using the autosplitter, open an issue in the GitHub repository.

2. **Suggest Improvements**: If you have ideas for new features or improvements in the code, open an issue on GitHub to discuss them with the community.

3. **Submit Pull Requests**: If you have made changes or improvements to the code, submit a pull request. Make sure to follow the contribution guidelines and that your code is well-documented.

4. **Documentation**: Help improve the project's documentation by adding or updating information in the README files or the project wiki.

5. **Translations**: If you can help translate the project or code messages into other languages, open a pull request with the translations.

6. **Share and Promote**: Share the project with other speedrunners and video game enthusiasts. The more people use and contribute to the project, the better it will be.

## License
This project is licensed under the [Licencia MIT](https://opensource.org/licenses/MIT)