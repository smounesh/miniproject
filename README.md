# Miniproject
A simple banking system API's build using aspnet6

# TLD API modules
  - User Authentication 
  - Account Management
  - Transaction Management
  - User Management

# LLD API endpints
    - User Authentication Endpoints
        - POST /api/auth/register: Register a new user
        - POST /api/auth/login: Log in a user
        - POST /api/auth/logout: Log out a user
        - POST /api/auth/reset-password: Reset password
    
    - Customer Endpoints
        - Account Management
            - GET /api/accounts: Retrieve all accounts for the logged-in user
            - POST /api/accounts: Create a new account
            - GET /api/accounts/{accountId}: Retrieve details of a specific account
            - PUT /api/accounts/{accountId}: Update account details
            - DELETE /api/accounts/{accountId}: Close an account
        
        - Transaction Management
            - POST /api/transactions/deposit: Deposit money into an account
            - POST /api/transactions/withdraw: Withdraw money from an account
            - POST /api/transactions/transfer: Transfer money between accounts
            - GET /api/transactions: Retrieve transaction history for the logged-in user


    - Employee Endpoints
        - Customer Account Management
            - GET /api/employees/customers/{customerId}/accounts: Retrieve all accounts for a specific customer
            - POST /api/employees/customers/{customerId}/accounts: Create a new account for a customer
            - PUT /api/employees/accounts/{accountId}: Update account details for a customer
            - DELETE /api/employees/accounts/{accountId}: Close a customer account

        - Transaction Management
            - POST /api/employees/transactions/approve: Approve large transactions
            - POST /api/employees/transactions/deposit: Process in-branch deposits
            - POST /api/employees/transactions/withdraw: Process in-branch withdrawals

        - Loan and Credit Management
            - POST /api/employees/loans/process: Process a loan application
            - GET /api/employees/loans/{loanId}: Retrieve loan details
            - PUT /api/employees/loans/{loanId}: Update loan details

    - Administrator Endpoints
        - User Management
            - POST /api/admin/users: Create a new employee account
            - GET /api/admin/users: Retrieve all employee accounts
            - PUT /api/admin/users/{userId}: Update employee account details
            - DELETE /api/admin/users/{userId}: Deactivate an employee account
            - POST /api/admin/users/{userId}/roles: Assign roles and permissions

# ERD
![alt text](image.png)