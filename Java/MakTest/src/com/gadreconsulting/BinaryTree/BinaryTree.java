package com.gadreconsulting.BinaryTree;

public class BinaryTree<T extends Comparable<T>> {

	private boolean _fSelfBalancing = true;
	private boolean _fBidirectional = false;
	private Node<T> _nodeRoot;

	public BinaryTree(boolean fSelfBalancing, boolean fBidirectional) {
		_nodeRoot = null;
		_fBidirectional = fBidirectional;
		_fSelfBalancing = fSelfBalancing;
	}

	public boolean fIsEmpty() {
		return (_nodeRoot == null);
	}

	public boolean fLocate(T tValue) {
		return fLocateRecursive(_nodeRoot, tValue);
	}

	public void makeEmpty() {
		_nodeRoot = null;
	}

	public void put(T tPayload) {
		_nodeRoot = putRecursive(_nodeRoot, tPayload);
		if (_fBidirectional) {
			adjustParentLinksRecursive(_nodeRoot, null);
		}
	}

	public int size() {
		return computeSizeRecursive(_nodeRoot);
	}

	public void traverseTree(ETraversal et, IBBTreeTraversalCallback<T> tcb) {
		switch (et) {
		case InOrder:
			traverseInOrderRecursive(_nodeRoot, tcb);
			break;
		case PostOrder:
			traversePostOrderRecursive(_nodeRoot, tcb);
			break;
		case PreOrder:
			traversePreOrderRecursive(_nodeRoot, tcb);
			break;
		}
	}

	private void adjustParentLinksRecursive(Node<T> node, Node<T> nodeParent) {
		node._nodeParent = nodeParent;
		if (node._nodeChildL != null) {
			adjustParentLinksRecursive(node._nodeChildL, node);
		}
		if (node._nodeChildR != null) {
			adjustParentLinksRecursive(node._nodeChildR, node);
		}
	}

	private int computeSizeRecursive(Node<T> node) {
		int nCount = 0;
		if (node != null) {
			nCount = 1;
			nCount += computeSizeRecursive(node._nodeChildL);
			nCount += computeSizeRecursive(node._nodeChildR);
		}
		return nCount;
	}

	private boolean fLocateRecursive(Node<T> node, T tValue) {
		boolean fFound = false;
		while ((node != null) && !fFound) {
			T tValueInTree = (T) node._tPayload;
			if (tValue.compareTo(tValueInTree) < 0)
				node = node._nodeChildL;
			else if (tValue.compareTo(tValueInTree) > 0)
				node = node._nodeChildR;
			else {
				fFound = true;
				break;
			}
			fFound = fLocateRecursive(node, tValue);
		}
		return fFound;
	}

	private int getDistance(Node<T> node) {
		return node == null ? -1 : node._jDist;
	}

	private Node<T> putRecursive(Node<T> node, T tPayload) {
		if (node == null) {
			node = new Node<T>(tPayload);
		} else {
			int jCompare = tPayload.compareTo((T) node._tPayload);
			if (jCompare < 0) {
				node._nodeChildL = putRecursive(node._nodeChildL, tPayload);
				if (_fSelfBalancing) {
					if (getDistance(node._nodeChildL) - getDistance(node._nodeChildR) == 2) {
						if (tPayload.compareTo((T) node._nodeChildL._tPayload) < 0) {
							node = adjustLeftChild(node);
						} else {
							node = adjustLeftChldrenRecursive(node);
						}
					}
				}
			} else if (jCompare > 0) {
				node._nodeChildR = putRecursive(node._nodeChildR, tPayload);
				if (_fSelfBalancing) {
					if (getDistance(node._nodeChildR) - getDistance(node._nodeChildL) == 2) {
						if (tPayload.compareTo((T) node._nodeChildR._tPayload) > 0) {
							node = adjustRightChild(node);
						} else {
							node = adjustRightChldrenRecursive(node);
						}
					}
				}
			}
		}

		node._jDist = Math.max(getDistance(node._nodeChildL), getDistance(node._nodeChildR)) + 1;
		return node;
	}

	private Node<T> adjustLeftChldrenRecursive(Node<T> node) {
		node._nodeChildL = adjustRightChild(node._nodeChildL);
		return adjustLeftChild(node);
	}

	private Node<T> adjustRightChldrenRecursive(Node<T> node) {
		node._nodeChildR = adjustLeftChild(node._nodeChildR);
		return adjustRightChild(node);
	}

	private Node<T> adjustLeftChild(Node<T> node) {
		Node<T> nodeTemp = node._nodeChildL;
		node._nodeChildL = nodeTemp._nodeChildR;
		nodeTemp._nodeChildR = node;
		node._jDist = Math.max(getDistance(node._nodeChildL), getDistance(node._nodeChildR)) + 1;
		nodeTemp._jDist = Math.max(getDistance(nodeTemp._nodeChildL), node._jDist) + 1;
		return nodeTemp;
	}

	private Node<T> adjustRightChild(Node<T> node) {
		Node<T> nodeTemp = node._nodeChildR;
		node._nodeChildR = nodeTemp._nodeChildL;
		nodeTemp._nodeChildL = node;
		node._jDist = Math.max(getDistance(node._nodeChildL), getDistance(node._nodeChildR)) + 1;
		nodeTemp._jDist = Math.max(getDistance(nodeTemp._nodeChildR), node._jDist) + 1;
		return nodeTemp;
	}

	private boolean traverseInOrderRecursive(Node<T> node, IBBTreeTraversalCallback<T> tcb) {
		boolean fRet = true;
		if (node != null) {
			fRet = traverseInOrderRecursive(node._nodeChildL, tcb);
			if (fRet) {
				fRet = tcb.fHandle(node);
				if (fRet) {
					fRet = traverseInOrderRecursive(node._nodeChildR, tcb);
				}
			}
		}
		return fRet;
	}

	private boolean traversePostOrderRecursive(Node<T> node, IBBTreeTraversalCallback<T> tcb) {
		boolean fRet = true;
		if (node != null) {
			fRet = traversePostOrderRecursive(node._nodeChildL, tcb);
			if (fRet) {
				fRet = traversePostOrderRecursive(node._nodeChildR, tcb);
				if (fRet) {
					fRet = tcb.fHandle(node);
				}
			}
		}
		return fRet;
	}

	private boolean traversePreOrderRecursive(Node<T> node, IBBTreeTraversalCallback<T> tcb) {
		boolean fRet = true;
		if (node != null) {
			fRet = tcb.fHandle(node);
			if (fRet) {
				fRet = traversePreOrderRecursive(node._nodeChildL, tcb);
				if (fRet) {
					fRet = traversePreOrderRecursive(node._nodeChildR, tcb);
				}
			}
		}
		return fRet;
	}

	private T getRecursive(Node<T> tNodeCur, T tSearchFor) {
		T tRet = null;
		int jComp = tSearchFor.compareTo(tNodeCur._tPayload);
		if (jComp == 0) {
			// Found it.
			tRet = tNodeCur._tPayload;
		} else {
			if (jComp < 0) {
				if (tNodeCur._nodeChildL != null) {
					tRet = getRecursive(tNodeCur._nodeChildL, tSearchFor);
				}
			} else {
				if (tNodeCur._nodeChildR != null) {
					tRet = getRecursive(tNodeCur._nodeChildR, tSearchFor);
				}
			}
		}
		return tRet;
	}

	public T get(T t) {
		T tRet = null;
		Node<T> tRoot = this._nodeRoot;
		tRet = getRecursive(this._nodeRoot, t);
		return tRet;
	}
}