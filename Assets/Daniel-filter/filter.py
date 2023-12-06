import pandas as pd

# Read the input CSV file
input_file = 'input.csv'
df = pd.read_csv(input_file)

# Filter rows where the Country is 'US'
filtered_df = df[df['Country'] == 'US']

# Remove the 'Region' and 'Country' columns
filtered_df = filtered_df.drop(['Region', 'Country'], axis=1)

# Save the filtered data to the output CSV file
output_file = 'output.csv'
filtered_df.to_csv(output_file, index=False)

print(f"Filtered data saved to {output_file}")
