# Simple Search Engine

This simple search engine is implemented in C# and serves as an inverted index, capable of running in memory and returning a sorted list of documents based on TF-IDF (Term Frequency-Inverse Document Frequency).

## Features

- Accepts a list of documents.
- Supports searches for single terms in the document set.
- Returns a list of matching documents sorted by TF-IDF.

## Implementation Details

### Inverted Index
- The inverted index is implemented using a dictionary data structure.
- Each term in the documents is associated with a list of document IDs in which the term appears.
- TF-IDF scores are calculated for each document-term pair to rank the documents.

### Tokenization
- Tokenization is performed by splitting the document text into individual words.
- Special characters like spaces, commas, periods, exclamation marks, and question marks are used as delimiters.

### TF (Term Frequency) Calculation
- Term frequency is calculated as the ratio of the number of occurrences of the term in a document to the total number of words in that document.

### IDF (Inverse Document Frequency) Calculation
- IDF is calculated as the logarithm of the total number of documents divided by the number of documents containing the term.

## Example
Consider the following documents indexed:

Document 1: "the brown fox jumped over the brown dog"  
Document 2: "the lazy brown dog sat in the corner"  
Document 3: "the red fox bit the lazy dog"

A search for the term "brown" should return the list: [Document 1, Document 2]  
A search for the term "fox" should return the list: [Document 3, Document 1]

## Usage
1. Populate the search engine with documents using the `IndexDocument` method.
2. Enter a search term using the console interface.
3. The search engine will return a list of matching documents sorted by TF-IDF.

## Notes
- The search engine operates solely in memory and does not persist the index to disk.
- Documents are represented as simple strings.
- No graphical user interface (GUI) is provided; interaction is done via the console.

## Dependencies
- This project utilizes the following dependencies:
  - Moq: A popular mocking library for .NET.
  - AutoFixture: A library for generating test data.
  - AutoFixture.Xunit2: An extension for AutoFixture to use with xUnit tests.

## Running Tests
- Ensure all dependencies are installed.
- Run the tests using your preferred test runner.

---
This project is part of a Java assignment and has been implemented in C# for demonstration purposes only.
