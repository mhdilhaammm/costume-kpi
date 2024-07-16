function deleteData(id) {
    event.preventDefault()
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            // User confirmed the delete action, proceed with the delete request
            $.ajax({
                url: '/IndikatorKPI/Delete', // Replace with the actual URL for the delete action
                type: 'POST', // Use the appropriate HTTP method
                data: { id: id }, // Send the data to be deleted
                success: function () {
                    // Handle the successful response, e.g., remove the deleted item from the UI
                    Swal.fire({
                        icon: 'success',
                        title: 'Data Deleted Successfully',
                        showConfirmButton: false,
                        timer: 1500
                    })
                    location.reload()
                },
                error: function (xhr, status, error) {
                    // Handle the error response, e.g., show an error message
                    Swal.fire({
                        icon: 'error',
                        title: 'Error Deleting Data',
                        text: 'An error occurred while deleting the data.',
                        showCancelButton: false,
                        showConfirmButton: true,
                        confirmButtonColor: '#dc3545',
                        confirmButtonText: 'OK'
                    });
                }
            });
        }
    });
}