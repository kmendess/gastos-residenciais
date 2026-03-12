interface ConfirmDeleteModalProps {
  show: boolean
  title?: string
  message?: string
  onConfirm: () => void
  onCancel: () => void
}

function ConfirmDeleteModal({
  show,
  title = "Confirmar exclusão",
  message = "Deseja realmente excluir este registro?",
  onConfirm,
  onCancel
}: ConfirmDeleteModalProps) {

  if (!show) return null;

  return (
    <>
      <div className="modal fade show d-block">
        <div className="modal-dialog modal-dialog-centered">
          <div className="modal-content">

            <div className="modal-header">
              <h5 className="modal-title">{title}</h5>
              <button
                className="btn-close"
                onClick={onCancel}
              />
            </div>

            <div className="modal-body">
              <p>{message}</p>
            </div>

            <div className="modal-footer">
              <button className="btn btn-secondary" onClick={onCancel}>
                Cancelar
              </button>

              <button className="btn btn-danger" onClick={onConfirm}>
                Excluir
              </button>
            </div>

          </div>
        </div>
      </div>

      <div className="modal-backdrop fade show"></div>
    </>
  );
}

export default ConfirmDeleteModal