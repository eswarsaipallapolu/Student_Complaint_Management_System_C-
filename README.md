"# Student_Complaint_Management_System_C#-" 


STUDENT COMPLAINT MANAGEMENT SYSTEM 

Project Proposal :  
Project Name : Student Complaint Management System (SCMS) 
Programming Languages : C# , XAML, SQLite 
 
1. Introduction 
The Student Complaint Management System (SCMS) is a WPF-based application that allows 
students to submit complaints and enables administrators to track and resolve them. The project 
is built using the MVVM (Model-View-ViewModel) architecture to ensure modularity and 
maintainability. 
 
2. Target Users 
• Students : Can submit complaints, track complaint statuses, and receive updates. 
• Administrators : Can review, update, and resolve complaints efficiently. 
 
3. Key Features 
Student Features 
Submit Complaints : Students can file complaints with details like category, 
description, and priority. 
         View Complaint Status : Students can track the progress of their complaints. 
         Edit or Delete : Before resolution, students can modify or remove their  complaints. 
        Administrator Features 
View Complaints : Admins can filter complaints by status, date, or category. 
Update Complaint Status : Admins can mark complaints as "Pending," "In 
Progress," or "Resolved." 
Assign Complaints : Complaints can be assigned to responsible personnel for 
resolution. 
       Common Features 
User Authentication : Login system for students and admins. 
Search & Filter : Search complaints based on category, date, or status. 
Export Data : Save complaints as CSV/PDF for records. 
4. MVVM Architecture Integration 
• Model (M) : Represents the `Complaint` and `User` classes, handling data storage and 
logic. 
• ViewModel (VM) : Connects data and UI, manages user interactions, and handles 
commands. 
• View (V) : Provides UI components, including buttons, text boxes, and data grids, using 
WPF XAML. 
 
5. Use Case Scenarios 
• Student Submits a Complaint 
    - The student logs in and fills out the complaint form. 
    - The system saves the complaint and assigns a unique ID. 
   - A confirmation message is displayed. 
• Admin Resolves a Complaint 
    - The admin logs in and reviews pending complaints. 
   - The admin updates the complaint status to "Resolved" with a resolution note. 
    - The student gets notified about the update. 
 
6. Project Execution & Presentation 
• Development Tools : Visual Studio, C# (.NET 5), WPF, SQLite 
• Final Presentation : Live demo showcasing submission, tracking, and resolution of 
complaints. 
• Architecture Explanation : Overview of MVVM structure and data handling. 
 
7. Agenda and Scope 
• Objective: Develop an efficient system for students to submit complaints and track 
resolutions. 
• Problem Addressed: Lack of a structured platform for complaint management in 
institutions. 
• Expected Outcome: A streamlined process for complaint submission, tracking, and 
resolution. 
• Scalability: Can be extended to mobile applications or integrated with institutional 
portals. 
• Security Measures: Role-based authentication ensures data privacy and integrity.
