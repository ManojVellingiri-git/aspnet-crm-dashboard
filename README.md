# LeadFlow: ASP.NET Core CRM Lead Dashboard

An interactive, custom-coded CRM Lead Dashboard built from scratch using ASP.NET Core MVC (C#) and Entity Framework Core (SQLite). This project demonstrates software engineering credentials, showing prospects your capability to build robust sales pipeline databases.

---

## 🚀 Core Features
1. **Interactive Kanban Board**: Direct drag-and-drop HTML5 Kanban pipeline cards grouped by status (New, Contacted, Qualified, Booked). Moving a card triggers a POST call to update the database state in real-time.
2. **Chart.js Lead Reporting**: Renders lead pipeline distribution and fit-score quality analysis using Chart.js visualization.
3. **Database Integration**: Entity Framework Core with a SQLite database (`crm_database.db`). Seeding triggers automatically on the first startup.
4. **Custom Lead Capture**: Modular form interface to add prospects with specific details (name, email, niche, revenue, fit score, bottleneck).

---

## 📁 Repository Structure
```
aspnet_crm_dashboard/
├── Controllers/
│   └── DashboardController.cs   # Main controller for dashboard routes and API actions
├── Data/
│   └── CrmDbContext.cs          # Entity Framework database configuration and lead seeds
├── Models/
│   └── Lead.cs                  # C# Model class representing the Lead database table
├── Views/
│   └── Dashboard/
│       └── Index.cshtml         # Responsive dark-theme Razor view, Chart.js, & Kanban JS
├── aspnet_crm_dashboard.csproj  # .NET project configuration with NuGet references
├── Program.cs                   # Entry point registering services and databases
└── README.md                    # Setup and operations guide
```

---

## 🛠️ Installation & Setup

### 1. Prerequisites
Ensure you have the **.NET SDK 9.0** installed on your system. Run this command to verify:
```bash
dotnet --version
```

### 2. Restore Dependencies & Build
Restore NuGet packages and compile the project to ensure zero errors:
```bash
dotnet restore
dotnet build
```

### 3. Launch the Server
Start the development web server:
```bash
dotnet run
```
The console will log the local URLs (usually `http://localhost:5000` or `http://localhost:5050` depending on your environment). 

Open your web browser and navigate to the local URL.

---

## 🧪 Local Testing & Kanban Operations

1. **View Seeds**: The dashboard will pre-load 10 leads matching target niches (Dutch Coach Jeroen, Cult Media, medspas, care homes) with color-coded fit scores.
2. **Drag & Drop**: Grab any lead card (e.g. *Cult Media UGC*) and drag it to a new column. The frontend calls `/Dashboard/UpdateStatus` via fetch API and updates the local SQLite database state.
3. **Chart Refresh**: The charts on top update in real-time to reflect pipeline changes.
4. **Form Logging**: Click **+ Add Custom Lead** to submit a new prospect and see the statistics metrics scale immediately.
