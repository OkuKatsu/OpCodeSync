import os
import argparse
from datetime import datetime

# Function to get the latest folder based on the date in the folder name
def get_latest_folder(folders):
    latest_folder = None
    latest_date = None
    
    for folder in folders:
        # Extract the date part from the folder name
        try:
            date_str = folder.split('_')[1]  # Get the date after the underscore
            folder_date = datetime.strptime(date_str, "%Y.%m.%d")  # Convert to datetime object
            
            # Check if it's the latest folder
            if latest_date is None or folder_date > latest_date:
                latest_date = folder_date
                latest_folder = folder
        except Exception as e:
            print(f"Skipping folder {folder} due to error: {e}")
    
    return latest_folder

# Function to read the 'machina.txt' file inside the folder
def read_machina_txt(folder_path):
    machina_txt_path = os.path.join(folder_path, "machina.txt")
    if os.path.exists(machina_txt_path):
        with open(machina_txt_path, 'r') as file:
            return file.read()  # Return the content of machina.txt
    else:
        print(f"machina.txt not found in {folder_path}")
        return None

# Main function to process the output folder
def process_output_folder(output_dir):
    prefixes = ["CN", "Global", "KR"]  # Define the prefixes to search for
    result_dict = {}  # Dictionary to store the results

    for prefix in prefixes:
        # List all folders starting with the prefix
        folders = [f for f in os.listdir(output_dir) if f.startswith(prefix) and os.path.isdir(os.path.join(output_dir, f))]
        
        if folders:
            # Get the latest folder based on the date
            latest_folder = get_latest_folder(folders)
            folder_path = os.path.join(output_dir, latest_folder)

            # Read the machina.txt file inside the latest folder
            machina_txt_content = read_machina_txt(folder_path)
            if machina_txt_content:
                result_dict[latest_folder] = machina_txt_content  # Save the content in the dictionary

    return result_dict

# Main function to parse the arguments and execute the script
if __name__ == "__main__":
    # Setting up the argument parser
    parser = argparse.ArgumentParser(description="Process output directory to find the latest folders and read machina.txt files.")
    parser.add_argument('output_dir', type=str, help='Path to the output directory')

    # Parse arguments
    args = parser.parse_args()

    # Process the output folder and get the result
    result = process_output_folder(args.output_dir)
    
    # Print the results
    for folder, content in result.items():
        print(f"Folder: {folder}\nContent:\n{content}\n")
