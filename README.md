# G-AM View

Petit exécutable Windows Forms qui démarre/arrête un pipeline GStreamer et affiche le flux vidéo H.265 RTP dans la fenêtre de l'application. Onglet Lecture pour le flux + stats, onglet Options pour ajuster le pipeline ou le chemin GStreamer.

## Prérequis

- .NET 8 SDK (déjà utilisé pour ce projet).
- GStreamer MSVC x86_64 installé dans `C:\gstreamer\1.0\msvc_x86_64` (le chemin est configuré dans `Program.cs`; ajustez-le si besoin).
- Le pipeline utilise `d3dvideosink` pour s'intégrer à la fenêtre.

## Lancer en mode dev

```powershell
dotnet build
.\GAMView.App\bin\Debug\net8.0-windows\GAMView.App.exe
```

## Générer un .exe de distrib

```powershell
dotnet publish GAMView.App/GAMView.App.csproj -c Release -r win-x64 --self-contained false
```

L'exécutable sera dans `GAMView.App\bin\Release\net8.0-windows\win-x64\`.

## Utilisation dans l'application

1. Vérifiez que le flux UDP arrive bien sur le port configuré (par défaut 5001).
2. Cliquez sur `Démarrer` pour lancer la pipeline :
   ```
   udpsrc port=<port> caps="application/x-rtp,media=video,encoding-name=H265,payload=96,clock-rate=90000" \
   ! rtpjitterbuffer latency=500 drop-on-latency=true \
   ! rtph265depay ! h265parse ! avdec_h265 ! videoconvert ! d3dvideosink name=vsink sync=false
   ```
3. Cliquez sur `Arrêter` pour remettre le pipeline à l'état `NULL` (équivalent d'un CTRL+C propre).

### Options supplémentaires
- Onglet **Options** : éditez le pipeline (place-holder `{port}` remplacé par le port saisi), remettez la version par défaut avec "Par défaut".
- Chemin GStreamer : renseignez votre installation (par ex. `C:\gstreamer\1.0\msvc_x86_64`) puis cliquez sur "Appliquer".
- Statistiques en lecture : débit approximatif (Mbit/s), FPS, latence (QOS/jitterbuffer) et pertes (statistiques `rtpjitterbuffer`).

En cas d'installation GStreamer à un autre emplacement, utilisez l'onglet Options ou ajustez `DefaultGstBasePath` dans `GAMView.App/Program.cs`.
