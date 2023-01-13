import subprocess
import time
import webbrowser
import sys

API_COMMANDS = ['start', 'dotnet', 'run']
CLIENT_COMMANDS = ['start', 'ng', 'serve']

def api():
  # Activate the API server
  api_process = subprocess.Popen(API_COMMANDS, shell=True, cwd='API')
  print("\n✔️ SkiNET API launched\n")
  return


def client():
  # Activate the client server
  client_process = subprocess.Popen(CLIENT_COMMANDS, shell=True, cwd='client')
  print("\n✔️ Client server launched\n")
  return


def redis():
  # Launch Redis Docker containers
  subprocess.run(['docker', 'start', 'skinet-e-commerce-redis-commander-1'])
  subprocess.run(['docker', 'start', 'skinet-e-commerce-redis-1'])
  print("\n✔️ Redis containers launched\n")
  return


def run_all():
  api()
  client()
  redis()
    
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
  if len(sys.argv) != 2:
    raise Exception("Command must contain two (2) arguments: python dev.py [function]")
  else:
    globals()[sys.argv[1]]()