//non-taxable amount of earnings
var nonTaxable = 18300;

/*
 * Function for salary calculate
 */
function Calculate() {
    var netSalary = document.getElementById("netSalary").value;
    
    var grossSalary = calculationGrossSalary(netSalary);
    var taxableBasa = grossSalary - nonTaxable;

    document.getElementById("taxableBasa").value = taxableBasa.toFixed(2);
    // Tax 10%
    document.getElementById("tax").value = percentage(taxableBasa, 10).toFixed(2);
    // PIO 14%
    document.getElementById("pioTaxEmployee").value = percentage(grossSalary, 14).toFixed(2);
    // Health Insurance 5,15%
    document.getElementById("heltTaxEmployee").value = percentage(grossSalary, 5, 15).toFixed(2);
    // Unemployment 0,75%
    document.getElementById("unemploymentTaxEmployee").value = percentage(grossSalary, 0.75).toFixed(2);
    document.getElementById("grossSalary").value = grossSalary.toFixed(2);
    // PIO at the expense of the employer 11,5%
    document.getElementById("pioTaxEmployer").value = percentage(grossSalary, 11, 5).toFixed(2);
    // Health Insurance at the expense of the employer 5,15%
    document.getElementById("heltTaxEmployer").value = percentage(grossSalary, 5, 15).toFixed(2);
    document.getElementById("superGrossSalary").value = (grossSalary + percentage(grossSalary, 11, 5) + percentage(grossSalary, 5, 15)).toFixed(2);
}

/*
 * Function for check whether salary calculated
 */
function cekFromUpdate() {
    const form = document.getElementById("form");

    form.addEventListener('submit', (e) => {

        var netSalary = document.getElementById("netSalary").value;
        var grossSalary = calculationGrossSalary(netSalary).toFixed(2);
        var a = document.getElementById("grossSalary").value;

        if (a != grossSalary) {
            
            swal({
                title:'Error!',
                text: 'You mast to calculate salary!',
                icon: 'error',
                confirmButtonText: 'Cool'
            });
            e.preventDefault()
        }
    })
    
}

/*
 * Function for calculation percentage
 */
function percentage(num, per) {
    return (num / 100) * per;
}


/**
 *  The formula for calculating gross salary is:
 * (net salary - 10 % tax exemption) / 0.71
 *
 * Function for calculating gross salary
 */
function calculationGrossSalary(netSalary) {

    var grossSalary = (netSalary - percentage(nonTaxable, 10)) / 0.71;
    /*
     ** The minimum contribution base in Serbia is currently 28402.
     */
    if (grossSalary < 28402) {
        grossSalary = 28402;
    }
    return grossSalary;
}