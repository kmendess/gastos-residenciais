interface TableListProps<T extends { id: number }> {
  data: T[];
  columns: { header: string; key: keyof T }[];
  loading?: boolean;
  total?: number;
  onEdit?: (item: T) => void;
  onDelete?: (item: T) => void;
}

function TableList<T extends { id: number }>({
  data,
  columns,
  loading = false,
  total,
  onEdit,
  onDelete
}: TableListProps<T>) {

  return (
    <>
      <div className="table-responsive">
        <table className="table table-striped table-hover">

          <thead>
            <tr>

              {columns.map((col) => (
                <th key={String(col.key)}>
                  {col.header}
                </th>
              ))}

              {(onEdit || onDelete) && (
                <th style={{ width: "120px" }}>
                  Ações
                </th>
              )}

            </tr>
          </thead>

          <tbody>

            {loading && (
              <tr>
                <td colSpan={columns.length + 1} className="text-center">

                  <div className="d-flex justify-content-center align-items-center p-3">
                    <div className="spinner-border me-2" role="status" />
                      Carregando...
                  </div>

                </td>
              </tr>
            )}

            {!loading && data.length === 0 && (
              <tr>
                <td colSpan={columns.length + 1} className="text-center p-3">
                  Nenhum registro encontrado
                </td>
              </tr>
            )}

            {!loading && data.map((item) => (
              <tr key={item.id}>

                {columns.map((col) => (
                  <td key={String(col.key)}>
                    {String(item[col.key])}
                  </td>
                ))}

                {(onEdit || onDelete) && (
                  <td>

                    {onEdit && (
                      <button className="btn btn-sm btn-outline-primary me-2" title="Editar" onClick={() => onEdit(item)}>
                        <i className="bi bi-pencil"></i>
                      </button>
                    )}

                    {onDelete && (
                      <button
                        className="btn btn-sm btn-outline-danger"
                        title="Excluir"
                        onClick={() => onDelete(item)}
                      >
                        <i className="bi bi-trash"></i>
                      </button>
                    )}

                  </td>
                )}

              </tr>
            ))}

          </tbody>

        </table>

      </div>

      {total !== undefined && !loading && (
        <div className="d-flex justify-content-end text-muted small mt-1">
          Total de registros: {total}
        </div>
      )}
    </>
  );
}

export default TableList