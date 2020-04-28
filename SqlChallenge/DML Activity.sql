-- 1. List all customers (full names, customer ID, and country) who are not in the US
Select FirstName,LastName, CustomerId,Country From Customer Where Country != 'US';
-- 2. List all customers from brazil
Select * From Customer Where Country = 'Brazil';
-- 3. List all sales agents
Select * From Employee;
-- 4. Show a list of all countries in billing addresses on invoices.
Select Distinct(BillingCountry) From Invoice;
-- 5. How many invoices were there in 2009, and what was the sales total for that year?
Select Count(InvoiceID) As NumInvoices, Sum(Total) As TotalSales From Invoice Where InvoiceDate >= '2009-01-01' AND InvoiceDate <= '2009-12-31';
-- 6. How many line items were there for invoice #37?
Select Count(InvoiceLineId) As ItemCountInvoice37 From InvoiceLine Where InvoiceId = 37;
-- 7. How many invoices per country?
Select Count(InvoiceId) As TotalInvoices,BillingCountry From Invoice Group by BillingCountry;
-- 8. Show total sales per country, ordered by highest sales first.
Select Sum(Total) As TotalSales, BillingCountry From Invoice Group By BillingCountry Order By Sum(Total) DESC;
