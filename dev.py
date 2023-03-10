import subprocess
import time
import webbrowser
import sys

API_COMMANDS = ['start', 'dotnet', 'run']
CLIENT_COMMANDS = ['start', 'ng', 'serve']
REDIS_COMMANDS = ['docker-compose', 'up', '--detach']

EXCEPTION_MSG = """

Command must contain less than two (2) arguments: py -m dev <optional>

<optional> arguments can include:

  api     |   runs the .NET API server
  client  |   runs the Angular client server
  redis   |   runs the Redis Docker containers (have Docker Desktop running beforehand)

NOTE: Turn on Docker Desktop before running beforehand before running the script
"""

def api():
  # Activate the API server
  api_process = subprocess.Popen(API_COMMANDS, shell=True, cwd='API')
  print("\n✔️  SkiNET API launched\n")
  return


def client():
  # Activate the client server
  client_process = subprocess.Popen(CLIENT_COMMANDS, shell=True, cwd='client')
  print("\n✔️  Client server launched\n")
  return


def redis():
  # Launch Redis Docker containers
  subprocess.run(REDIS_COMMANDS)
  print("\n✔️  Redis containers launched\n")
  return


def main():
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
  print("🗄️ Redis Commander Database: http://localhost:8081")
  return


if __name__ == '__main__':
  if len(sys.argv) == 1:
    main()
  
  elif len(sys.argv) == 2:
    try:
      globals()[sys.argv[1]]()
    
    except KeyError:
      raise Exception(EXCEPTION_MSG)
  
  else:
    raise Exception(EXCEPTION_MSG)
    