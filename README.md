# Music AI Software

A dual-deck music player application with AI-assisted track recommendations using machine learning technology.

## Overview

Music AI Software is a Windows Forms application that provides professional DJ-style dual audio playback with intelligent music recommendations. The application analyzes your music library to suggest similar tracks based on audio characteristics like BPM (beats per minute).

## Features

### Dual Audio Players
- **Two independent audio players** for seamless track mixing and comparison
- **Individual volume controls** for each player
- **Play/pause controls** for precise playback management
- **Real-time progress tracking** with time display and progress bars
- **Drag and drop functionality** between playlist and players

### AI-Powered Recommendations
- **Machine learning analysis** of your music library
- **BPM-based similarity detection** for finding compatible tracks
- **Real-time suggestion updates** based on currently playing tracks

### Supported Audio Formats
- MP3
- WAV
- WMA
- AAC
- M4A

## Getting Started

### Prerequisites
- Windows operating system
- .NET Framework (compatible version)
- Audio files in supported formats

### Installation
1. Download and extract the Music AI Software application
2. Run the executable file
3. The application will open with the main interface

## How to Use

### Loading Your Music Library
1. **Menu Method**: Click on the track menu item in the application
2. **File Dialog**: Select multiple audio files using the file browser
3. **Analysis**: The application will automatically analyze your tracks for AI recommendations

### Playing Music
1. **Select a track** from the playlist on the left
2. **Click Play button** for Player 1 or Player 2
3. **Adjust volume** using the individual volume sliders
4. **Monitor progress** via the time displays and progress bars

### Using AI Recommendations
1. **Play or select a track** in either player
2. **Click the Refresh button** in the recommendations panel
3. **View suggested tracks** based on musical similarity
4. **Double-click any recommendation** to load it:
   - Loads to Player 1 if it's not playing
   - Loads to Player 2 if Player 1 is already playing
   - Replaces Player 1 if both players are active

### Drag and Drop Operation
- **Drag tracks** from the playlist to either player panel
- **Drop onto Player 1 or Player 2** to load and start playback
- **Visual feedback** indicates valid drop zones

## Technical Details

### Machine Learning Engine
- Uses **ML.NET framework** for recommendation processing
- Analyzes **audio characteristics** including BPM detection
- Creates **similarity models** based on track features
- Provides **real-time predictions** for track compatibility

### Audio Processing
- **NAudio library** for high-quality audio playback
- **Multi-format support** for various audio files

### Architecture
- **Interface-based design** for extensible audio player implementations
- **Async/await patterns** for responsive UI during analysis
- **Event-driven updates** for real-time progress and recommendations
- **Proper resource management** with disposable patterns

## User Interface

### Main Window Layout
- **Left Panel**: Music library playlist
- **Center**: Dual audio player controls with progress indicators
- **Right Panel**: AI-powered recommendations list
- **Top**: Menu bar for file operations

### Player Controls
- **Play/Pause buttons** for each deck
- **Volume sliders** (0-100 range)
- **Time displays** showing current position and total duration
- **Progress bars** with visual playback indication

## Troubleshooting

### Common Issues
- **No recommendations appearing**: Ensure you have multiple tracks loaded and analyzed
- **Audio not playing**: Check file format compatibility and audio device settings
- **Analysis taking long**: Large libraries require more processing time - be patient during initial analysis
- **Recommendation errors**: Try refreshing or reloading your music library