import subprocess, webbrowser

API_COMMANDS = ['start', 'dotnet', 'run']
CLIENT_COMMANDS = ['start', 'ng', 'serve']

def main():
  # Activate the API server
  api_process = subprocess.Popen(API_COMMANDS, shell=True, cwd='API')
  
  # Activate the client server
  client_process = subprocess.Popen(CLIENT_COMMANDS, shell=True, cwd='client')
  
  # Opens https://localhost:4200, Angular's development URL, in your browser
  webbrowser.open('https://localhost:4200', new=2)
if __name__ == '__main__':
  main()