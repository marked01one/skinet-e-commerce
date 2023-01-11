import subprocess, webbrowser
import time

API_COMMANDS = ['start', 'dotnet', 'run']
CLIENT_COMMANDS = ['start', 'ng', 'serve']

def main():
  # Activate the API server
  api_process = subprocess.Popen(API_COMMANDS, shell=True, cwd='API')
  print("\n\n✔️ ⬜⬜ SkiNET API launched\n\n")
  
  # Activate the client server
  client_process = subprocess.Popen(CLIENT_COMMANDS, shell=True, cwd='client')
  print("✔️ ✔️ ⬜ Client server launched\n\n")
  
  subprocess.run(['docker', 'start', 'skinet-e-commerce-redis-commander-1'])
  subprocess.run(['docker', 'start', 'skinet-e-commerce-redis-1'])
  print("✔️ ✔️ ✔️  Redis containers launched\n\n")
  
  for i in range(9):
    print("⏳"*(i % 3 + 1) + " Opening development URL...")
    time.sleep(0.5)
    print("\033[A                                                                    \033[A")
  
  # Opens https://localhost:4200, Angular's development URL, in your browser
  webbrowser.open('https://localhost:4200', new=2)

  print("💻 Development server: https://localhost:4200")
  print("🌐 API documentation: https://localhost:5001/swagger")
  print("🗄️ Redis Commander Database: http://127.0.0.1:8081")
  return
  
if __name__ == '__main__':
  main()
  