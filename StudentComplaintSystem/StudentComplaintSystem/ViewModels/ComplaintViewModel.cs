using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using StudentComplaintSystem.Models;
using StudentComplaintSystem.Services;

namespace StudentComplaintSystem.ViewModels
{
    public class ComplaintViewModel : INotifyPropertyChanged
    {
        private readonly DataService _dataService;
        private ObservableCollection<Complaint> _complaints;
        private Complaint _selectedComplaint;
        private Complaint _newComplaint;
        private UserRole _currentRole;
        private SortCriteria _sortCriteria;
        private bool _isSortAscending;
        private string _themeButtonText;

        public ComplaintViewModel(UserRole role)
        {
            _dataService = new DataService();
            CurrentRole = role;
            Complaints = new ObservableCollection<Complaint>(FilterComplaintsByRole(_dataService.LoadComplaints()));
            NewComplaint = new Complaint { SubmissionDate = DateTime.Now, Status = "Submitted" };
            SubmitComplaintCommand = new RelayCommand(SubmitComplaint, CanSubmitComplaint);
            UpdateComplaintCommand = new RelayCommand(UpdateComplaint, CanUpdateComplaint);
            SortComplaintsCommand = new RelayCommand(SortComplaints);
            LogoutCommand = new RelayCommand(Logout);
            ToggleThemeCommand = new RelayCommand(ToggleTheme);
            SortCriteria = SortCriteria.Id;
            IsSortAscending = true;
            ThemeButtonText = ThemeManager.IsDarkMode ? "Light Mode" : "Dark Mode";
        }

        public ObservableCollection<Complaint> Complaints
        {
            get => _complaints;
            set
            {
                _complaints = value;
                OnPropertyChanged();
            }
        }

        public Complaint SelectedComplaint
        {
            get => _selectedComplaint;
            set
            {
                _selectedComplaint = value;
                OnPropertyChanged();
            }
        }

        public Complaint NewComplaint
        {
            get => _newComplaint;
            set
            {
                _newComplaint = value;
                OnPropertyChanged();
            }
        }

        public UserRole CurrentRole
        {
            get => _currentRole;
            set
            {
                _currentRole = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsAdmin));
            }
        }

        public bool IsAdmin => CurrentRole == UserRole.Admin;

        public SortCriteria SortCriteria
        {
            get => _sortCriteria;
            set
            {
                _sortCriteria = value;
                OnPropertyChanged();
                SortComplaints(null);
            }
        }

        public bool IsSortAscending
        {
            get => _isSortAscending;
            set
            {
                _isSortAscending = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(SortDirectionText));
            }
        }

        public string SortDirectionText => IsSortAscending ? "Sort Descending" : "Sort Ascending";

        public string ThemeButtonText
        {
            get => _themeButtonText;
            set
            {
                _themeButtonText = value;
                OnPropertyChanged();
            }
        }

        public ICommand SubmitComplaintCommand { get; }
        public ICommand UpdateComplaintCommand { get; }
        public ICommand SortComplaintsCommand { get; }
        public ICommand LogoutCommand { get; }
        public ICommand ToggleThemeCommand { get; }

        private void SubmitComplaint(object parameter)
        {
            NewComplaint.StudentId = "student1";
            _dataService.AddComplaint(NewComplaint);
            Complaints.Add(NewComplaint);
            SortComplaints(null);
            NewComplaint = new Complaint { SubmissionDate = DateTime.Now, Status = "Submitted" };
        }

        private bool CanSubmitComplaint(object parameter) => CurrentRole == UserRole.Student;

        private void UpdateComplaint(object parameter)
        {
            if (SelectedComplaint != null)
            {
                _dataService.UpdateComplaint(SelectedComplaint);
                Complaints = new ObservableCollection<Complaint>(FilterComplaintsByRole(_dataService.LoadComplaints()));
                SortComplaints(null);
            }
        }

        private bool CanUpdateComplaint(object parameter) => IsAdmin && SelectedComplaint != null;

        private void SortComplaints(object parameter)
        {
            if (parameter != null && parameter.ToString() == "ToggleDirection")
            {
                IsSortAscending = !IsSortAscending;
            }

            var sortedComplaints = FilterComplaintsByRole(_dataService.LoadComplaints());
            switch (SortCriteria)
            {
                case SortCriteria.Id:
                    sortedComplaints = IsSortAscending
                        ? sortedComplaints.OrderBy(c => c.Id).ToList()
                        : sortedComplaints.OrderByDescending(c => c.Id).ToList();
                    break;
                case SortCriteria.SubmissionDate:
                    sortedComplaints = IsSortAscending
                        ? sortedComplaints.OrderBy(c => c.SubmissionDate).ToList()
                        : sortedComplaints.OrderByDescending(c => c.SubmissionDate).ToList();
                    break;
                case SortCriteria.Category:
                    sortedComplaints = IsSortAscending
                        ? sortedComplaints.OrderBy(c => c.Category).ToList()
                        : sortedComplaints.OrderByDescending(c => c.Category).ToList();
                    break;
                case SortCriteria.Status:
                    sortedComplaints = IsSortAscending
                        ? sortedComplaints.OrderBy(c => c.Status).ToList()
                        : sortedComplaints.OrderByDescending(c => c.Status).ToList();
                    break;
            }
            Complaints = new ObservableCollection<Complaint>(sortedComplaints);
        }

        private List<Complaint> FilterComplaintsByRole(List<Complaint> complaints)
        {
            if (CurrentRole == UserRole.Student)
            {
                return complaints.Where(c => c.StudentId == "student1").ToList();
            }
            return complaints;
        }

        private void Logout(object parameter)
        {
            LogoutRequested?.Invoke(this, EventArgs.Empty);
        }

        private void ToggleTheme(object parameter)
        {
            ThemeManager.IsDarkMode = !ThemeManager.IsDarkMode;
            ThemeButtonText = ThemeManager.IsDarkMode ? "Light Mode" : "Dark Mode";
        }

        public event EventHandler LogoutRequested;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}