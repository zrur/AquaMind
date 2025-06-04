// AquaMind JavaScript Functions

// Configuração global para AJAX requests
$.ajaxSetup({
    beforeSend: function(xhr, settings) {
        if (!/^(GET|HEAD|OPTIONS|TRACE)$/i.test(settings.type) && !this.crossDomain) {
            xhr.setRequestHeader("RequestVerificationToken", $('input[name="__RequestVerificationToken"]').val());
        }
    }
});

// Função para formatar valores de umidade
function formatHumidity(value) {
    return value ? value.toFixed(1) + '%' : 'N/A';
}

// Função para formatar datas
function formatDate(dateString) {
    if (!dateString) return 'N/A';
    const date = new Date(dateString);
    return date.toLocaleDateString('pt-BR') + ' ' + date.toLocaleTimeString('pt-BR');
}

// Função para mostrar alertas
function showAlert(message, type = 'info') {
    const alertHtml = `
        <div class="alert alert-${type} alert-dismissible fade show" role="alert">
            ${message}
            <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                <span aria-hidden="true">&times;</span>
            </button>
        </div>
    `;
    $('#alerts-container').html(alertHtml);
    
    // Auto-hide after 5 seconds
    setTimeout(() => {
        $('.alert').alert('close');
    }, 5000);
}

// Função para confirmar exclusões
function confirmDelete(message = 'Tem certeza que deseja excluir este item?') {
    return confirm(message);
}

// Função para ligar/desligar bomba
function togglePump(pumpId, currentStatus) {
    const action = currentStatus ? 'desligar' : 'ligar';
    
    if (confirm(`Tem certeza que deseja ${action} esta bomba?`)) {
        $.ajax({
            url: `/api/Bombas/${pumpId}/toggle`,
            method: 'PUT',
            success: function(response) {
                showAlert(`Bomba ${action}da com sucesso!`, 'success');
                // Recarregar a página ou atualizar o status
                location.reload();
            },
            error: function(xhr) {
                showAlert('Erro ao alterar status da bomba', 'danger');
            }
        });
    }
}

// Função para buscar dados de sensores em tempo real
function updateSensorData() {
    $('.sensor-data').each(function() {
        const sensorId = $(this).data('sensor-id');
        const element = $(this);
        
        $.ajax({
            url: `/api/Sensores/${sensorId}/latest`,
            method: 'GET',
            success: function(data) {
                if (data && data.valor !== undefined) {
                    element.find('.humidity-value').text(formatHumidity(data.valor));
                    element.find('.last-reading').text(formatDate(data.dataRegistro));
                    
                    // Atualizar cor baseado no valor
                    const humidityElement = element.find('.humidity-value');
                    humidityElement.removeClass('text-success text-warning text-danger');
                    
                    if (data.valor < 30) {
                        humidityElement.addClass('text-danger');
                    } else if (data.valor < 60) {
                        humidityElement.addClass('text-warning');
                    } else {
                        humidityElement.addClass('text-success');
                    }
                }
            },
            error: function() {
                console.log(`Erro ao buscar dados do sensor ${sensorId}`);
            }
        });
    });
}

// Inicialização quando o documento estiver pronto
$(document).ready(function() {
    // Atualizar dados dos sensores a cada 30 segundos
    if ($('.sensor-data').length > 0) {
        updateSensorData();
        setInterval(updateSensorData, 30000);
    }
    
    // Configurar tooltips do Bootstrap
    $('[data-toggle="tooltip"]').tooltip();
    
    // Configurar popovers do Bootstrap
    $('[data-toggle="popover"]').popover();
});
