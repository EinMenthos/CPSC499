import pandas as pd

# Read the input CSV file
input_file = 'input.csv'
df = pd.read_csv(input_file)

# Filter rows where the Country is 'US'
filtered_df = df[df['Country'] == 'US']
# Las Vegas, Los Angeles, Dallas, Seattle, Denver, Dallas, Chicago, Atlanta, New York City

# Remove the 'Region' and 'Country' columns
filtered_df = filtered_df.drop(['Region', 'Country'], axis=1)

# filtered_test = df[filtered_df['City'] == 'Las Vegas' | df['City'] == 'Seattle' | df['City'] == 'Denver' ]

# Save the filtered data to the output CSV file
output_file = 'output.csv'
#filtered_df.to_csv(output_file, index=False)

print(f"Filtered data saved to {output_file}")
